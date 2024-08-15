using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using ObsWebSocketSharp.Objs;
using ObsWebSocketSharp.Objs.Messages;
using ObsWebSocketSharp.Objs.Responses;

namespace ObsWebSocketSharp.Utils;

public static class ResponseUtils
{
    public static BaseResponse? DecodeResponse(this RequestResponseMessageObj message)
    {
        var obj = message.ResponseData as JObject;
        return message.RequestType switch
        {
            RequestName.GetVersion => obj?.ToObject<Response.GetVersion>(),
            RequestName.GetStats => obj?.ToObject<Response.GetStats>(),
            RequestName.BroadcastCustomEvent => obj?.ToObject<Response.BroadcastCustomEvent>(),
            RequestName.CallVendorRequest => obj?.ToObject<Response.CallVendorRequest>(),
            RequestName.GetHotkeyList => obj?.ToObject<Response.GetHotkeyList>(),
            RequestName.TriggerHotkeyByName => obj?.ToObject<Response.TriggerHotkeyByName>(),
            RequestName.TriggerHotkeyByKeySequence => obj?.ToObject<Response.TriggerHotkeyByKeySequence>(),
            RequestName.Sleep => obj?.ToObject<Response.Sleep>(),
            _ => null,
        };
    }
}
