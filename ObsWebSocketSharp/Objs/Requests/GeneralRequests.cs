using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ObsWebSocketSharp.Objs.Requests;

public static partial class Request
{
    public record GetVersion : BaseRequest
    {

    }

    public record GetStats : BaseRequest
    { 
        
    }

    public record BroadcastCustomEvent : BaseRequest
    {
        /// <summary>
        /// Data payload to emit to all receivers	
        /// </summary>
        [JsonProperty("eventData")]
        public object EventData { get; set; }
    }

    public record CallVendorRequest : BaseRequest
    {
        /// <summary>
        /// Name of the vendor to use
        /// </summary>
        [JsonProperty("vendorName")]
        public string VendorName { get; set; }
        /// <summary>
        /// The request type to call
        /// </summary>
        [JsonProperty("requestType")]
        public string RequestType { get; set; }
        /// <summary>
        /// Object containing appropriate request data	
        /// </summary>
        [JsonProperty("requestData")]
        public object? RequestData { get; set; }
    }

    public record GetHotkeyList : BaseRequest
    { 
        
    }

    public record TriggerHotkeyByName : BaseRequest
    {
        /// <summary>
        /// Name of the hotkey to trigger
        /// </summary>
        [JsonProperty("hotkeyName")]
        public string HotkeyName { get; set; }
        /// <summary>
        /// Name of context of the hotkey to trigger	
        /// </summary>
        [JsonProperty("contextName")]
        public string? ContextName { get; set; }
    }

    public record TriggerHotkeyByKeySequence : BaseRequest
    {
        public record KeyModifiersObj
        {
            /// <summary>
            /// Press Shift
            /// </summary>
            [JsonProperty("shift")]
            public bool Shift { get; set; }
            /// <summary>
            /// Press CTRL
            /// </summary>
            [JsonProperty("control")]
            public bool Control { get; set; }
            /// <summary>
            /// Press ALT
            /// </summary>
            [JsonProperty("alt")]
            public bool Alt { get; set; }
            /// <summary>
            /// Press CMD (Mac)
            /// </summary>
            [JsonProperty("command")]
            public bool Command { get; set; }
        }

        /// <summary>
        /// The OBS key ID to use. See https://github.com/obsproject/obs-studio/blob/master/libobs/obs-hotkeys.h
        /// </summary>
        [JsonProperty("keyId")]
        public string? KeyId { get; set; }
        /// <summary>
        /// Object containing key modifiers to apply
        /// </summary>
        [JsonProperty("keyModifiers")]
        public KeyModifiersObj? KeyModifiers { get; set; }
    }

    public record Sleep : BaseRequest
    {
        /// <summary>
        /// Number of milliseconds to sleep for (if SERIAL_REALTIME mode)
        /// </summary>
        [JsonProperty("sleepMillis")]
        public long? SleepMillis { get; set; }
        /// <summary>
        /// Number of frames to sleep for (if SERIAL_FRAME mode)
        /// </summary>
        [JsonProperty("sleepFrames")]
        public long? SleepFrames { get; set; }
    }
}



