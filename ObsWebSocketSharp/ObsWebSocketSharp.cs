using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ObsWebSocketSharp.Objs;
using ObsWebSocketSharp.Objs.Events;
using ObsWebSocketSharp.Objs.Messages;
using ObsWebSocketSharp.Utils;
using Websocket.Client;

namespace ObsWebSocketSharp;

public partial class ObsWebSocketSharp
{
    private readonly WebsocketClient _client;
    private readonly ConfigObj _config;
    private string _auth;
    private int _version;
    private EventSubscription _eventSubscription;

    public ClientState State { get; private set; }
    public bool Identified { get; private set; }
    public EventSubscription EventSubscription 
    {
        get
        {
            return _eventSubscription;
        }
        set
        {
            if (State == ClientState.Connected)
            {
                var data1 = WebSocketOpCode.Reidentify.MakeData(new ReidentifyMessageObj()
                {
                    EventSubscriptions = value
                });
                _client.Send(data1);
            }
            _eventSubscription = value;
        }
    }

    public event EventHandler<ClientState> StateChanged;
    public event EventHandler<DisconnectionInfo> Disconnect;
    public event Action<object?, ResponseMessage, Exception> MessageError;

    public event EventHandler<BaseEvent> ObsEvent;

    public ObsWebSocketSharp(ConfigObj config)
    {
        _config = config;

        StateChanged?.Invoke(this, State = ClientState.Init);
        var url = new Uri(_config.Url);

        _client = new WebsocketClient(url)
        {

        };
        _client.ReconnectionHappened.Subscribe(ReconnectionHappened);
        _client.MessageReceived.Subscribe(MessageReceived);
        _client.DisconnectionHappened.Subscribe(DisconnectionHappened);
    }

    public void Start()
    {
        StateChanged?.Invoke(this, State = ClientState.Connecting);

        _client.Start();

        StateChanged?.Invoke(this, State = ClientState.Connected);
    }

    public async Task Stop()
    {
        if (_client != null)
        {
            await _client.Stop(WebSocketCloseStatus.Empty, "");
        }
    }

    private void MessageReceived(ResponseMessage message)
    {
        if (message.MessageType == WebSocketMessageType.Text)
        {
            if (message.Text == null)
            {
                MessageError?.Invoke(this, message, new Exception("Message is empty"));
                return;
            }
            BaseMessageObj obj;
            try
            {
                var obj1 = JsonConvert.DeserializeObject<BaseMessageObj>(message.Text);
                if (obj1 == null)
                {
                    MessageError?.Invoke(this, message, new Exception("Json is empty"));
                    return;
                }
                obj = obj1;

                var data = obj.DecodeMessage();
                if (data == null)
                {
                    MessageError?.Invoke(this, message, new Exception("Message type error"));
                }
                if (data is HelloMessageObj hello)
                {
                    _version = hello.RpcVersion;
                    if (hello.Authentication is { } auth)
                    {
                        _auth = ProtocolUtils.MakeAuth(_config.Password, auth.Salt, auth.Challenge);
                    }

                    var data1 = WebSocketOpCode.Identify.MakeData(new IdentifyMessageObj()
                    {
                        RpcVersion = _version,
                        Authentication = _auth,
                        EventSubscriptions = _eventSubscription
                    });
                    _client.Send(data1);
                }
                else if (data is IdentifiedMessageObj identifiedMessage)
                {
                    Identified = true;
                }
                else if (data is EventMessageObj eventMessage)
                {
                    var ev = eventMessage.DecodeEvent();
                    if (ev == null)
                    {
                        MessageError?.Invoke(this, message, new Exception("Event decode fail"));
                        return;
                    }

                    ObsEvent?.Invoke(this, ev);
                }
                else if (data is RequestResponseMessageObj responseMessage)
                {
                    string uuid = responseMessage.RequestId;
                    var res = responseMessage.DecodeResponse();
                    if (res == null)
                    {
                        MessageError?.Invoke(this, message, new Exception($"Response {uuid} decode fail"));
                        Unlock(uuid, null);
                        return;
                    }
                    res.RequestStatus = responseMessage.RequestStatus;
                    Unlock(uuid, res);
                }
            }
            catch (Exception e)
            {
                MessageError?.Invoke(this, message, e);
                return;
            }
        }
    }

    private void ReconnectionHappened(ReconnectionInfo info)
    {
        StateChanged?.Invoke(this, State = ClientState.Reconnect);
    }

    private void DisconnectionHappened(DisconnectionInfo info)
    {
        Identified = false;
        StateChanged?.Invoke(this, State = ClientState.Disconnect);
        Disconnect?.Invoke(this, info);
    }
}
