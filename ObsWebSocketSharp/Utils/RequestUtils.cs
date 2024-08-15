using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObsWebSocketSharp.Objs;
using ObsWebSocketSharp.Objs.Requests;

namespace ObsWebSocketSharp.Utils;

public static class RequestUtils
{
    public static string? GetRequestType(this BaseRequest request)
    {
        if (request is Request.GetVersion)
        {
            return RequestName.GetVersion;
        }
        else if (request is Request.GetStats)
        {
            return RequestName.GetStats;
        }
        else if (request is Request.BroadcastCustomEvent)
        {
            return RequestName.BroadcastCustomEvent;
        }
        else if (request is Request.CallVendorRequest)
        {
            return RequestName.CallVendorRequest;
        }
        else if (request is Request.GetHotkeyList)
        {
            return RequestName.GetHotkeyList;
        }
        else if (request is Request.TriggerHotkeyByName)
        {
            return RequestName.TriggerHotkeyByName;
        }
        else if (request is Request.TriggerHotkeyByKeySequence)
        {
            return RequestName.TriggerHotkeyByKeySequence;
        }
        else if (request is Request.Sleep)
        {
            return RequestName.Sleep;
        }

        return null;
    }
}
