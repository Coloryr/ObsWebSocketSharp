using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ObsWebSocketSharp.Objs;
using ObsWebSocketSharp.Objs.Messages;
using ObsWebSocketSharp.Utils;
using Websocket.Client;

namespace ObsWebSocketSharp;

public class ObsWebSocketSharp
{
    private readonly WebsocketClient _client;
    private readonly ConfigObj _config;
    private string _auth;
    private int _version;

    public ClientState State { get; private set; }
    public EventSubscription EventSubscription { get; set; }

    public event EventHandler<ClientState> StateChanged;
    public event EventHandler<DisconnectionInfo> Disconnect;
    public event Action<object?, ResponseMessage, Exception> MessageError;

    public event EventHandler<object> ObsEvent;

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
            }
            catch (Exception e)
            {
                MessageError?.Invoke(this, message, e);
                return;
            }

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

                var data1 = ProtocolUtils.MakeData(WebSocketOpCode.Identify, new IdentifyMessageObj()
                {
                    RpcVersion = _version,
                    Authentication = _auth,
                    EventSubscriptions = EventSubscription
                });
                _client.Send(data1);
            }
            else if(data is EventMessageObj eventmessage)
            {

            }
        }
    }

    private void ReconnectionHappened(ReconnectionInfo info)
    {
        StateChanged?.Invoke(this, State = ClientState.Reconnect);
    }

    private void DisconnectionHappened(DisconnectionInfo info)
    {
        StateChanged?.Invoke(this, State = ClientState.Disconnect);
        Disconnect?.Invoke(this, info);
    }

    public void SetEventSubscription(EventSubscription value)
    {
        if (State != ClientState.Connected)
        {
            return;
        }

        var data1 = ProtocolUtils.MakeData(WebSocketOpCode.Reidentify, new ReidentifyMessageObj()
        {
            EventSubscriptions = value
        });
        _client.Send(data1);
        EventSubscription = value;
    }
}
