using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ObsWebSocketSharp.Objs;
using ObsWebSocketSharp.Objs.Events;
using ObsWebSocketSharp.Objs.Messages;
using ObsWebSocketSharp.Objs.Requests;

namespace ObsWebSocketSharp.Utils;

public static class ProtocolUtils
{
    public const string ProtocolHead = "Sec-WebSocket-Protocol";

    public static string ToString(this DataType type)
    {
        return type switch
        {
            DataType.Json => "obswebsocket.json",
            DataType.MsgPack => "obswebsocket.msgpack",
            _ => ""
        };
    }

    public static object? DecodeMessage(this BaseMessageObj message)
    {
        if (message.Data is not JObject obj)
        {
            return null;
        }
        switch (message.OpCode)
        {
            case WebSocketOpCode.Hello:
                return obj.ToObject<HelloMessageObj>();
            case WebSocketOpCode.Identified:
                return obj.ToObject<IdentifiedMessageObj>();
            case WebSocketOpCode.Event:
                return obj.ToObject<EventMessageObj>();
            case WebSocketOpCode.RequestResponse:
                return obj.ToObject<RequestResponseMessageObj>();
            case WebSocketOpCode.RequestBatchResponse:
                return obj.ToObject<RequestBatchResponseMessageObj>();
        }

        return null;
    }

    public static string MakeAuth(string password, string salt, string challenge)
    {
        var temp = SHA256.HashData(Encoding.UTF8.GetBytes(password + salt));
        string data = Convert.ToBase64String(temp);
        var temp1 = SHA256.HashData(Encoding.UTF8.GetBytes(data + challenge));
        return Convert.ToBase64String(temp1);
    }

    public static string MakeData(this WebSocketOpCode code, object data) 
    {
        var obj1 = new BaseMessageObj()
        {
            OpCode = code,
            Data = data
        };

        return JsonConvert.SerializeObject(obj1);
    }

    public static string MakeData(this BaseRequest request, string uuid)
    {
        var name = request.GetRequestType() ?? throw new Exception("Unsupported request type");
        var obj1 = new RequestMessageObj()
        {
            RequestType = name,
            RequestId = uuid,
            RequestData = request
        };

        return JsonConvert.SerializeObject(obj1);
    }
}
