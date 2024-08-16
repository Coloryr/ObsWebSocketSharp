using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ObsWebSocketSharp.Objs.Responses;

public static partial class Response
{
    /// <summary>
    /// Gets data about the current plugin and RPC version.
    /// </summary>
    public record GetVersion : BaseResponse
    {
        /// <summary>
        /// Current OBS Studio version
        /// </summary>
        [JsonProperty("obsVersion")]
        public string ObsVersion { get; set; }
        /// <summary>
        /// Current obs-websocket version
        /// </summary>
        [JsonProperty("obsWebSocketVersion")]
        public string ObsWebSocketVersion { get; set; }
        /// <summary>
        /// Current latest obs-websocket RPC version
        /// </summary>
        [JsonProperty("rpcVersion")]
        public int RpcVersion { get; set; }
        /// <summary>
        /// Array of available RPC requests for the currently negotiated RPC version
        /// </summary>
        [JsonProperty("availableRequests")]
        public List<string> AvailableRequests { get; set; }
        /// <summary>
        /// Image formats available in <see cref="GetSourceScreenshot"/> and <see cref="SaveSourceScreenshot"/> requests.
        /// </summary>
        [JsonProperty("supportedImageFormats")]
        public List<string> SupportedImageFormats { get; set; }
        /// <summary>
        /// Name of the platform. Usually windows, macos, or ubuntu (linux flavor). Not guaranteed to be any of those
        /// </summary>
        [JsonProperty("platform")]
        public string Platform { get; set; }
        /// <summary>
        /// Description of the platform, like Windows 10 (10.0)
        /// </summary>
        [JsonProperty("platformDescription")]
        public string PlatformDescription { get; set; }
    }

    /// <summary>
    /// Gets statistics about OBS, obs-websocket, and the current session.
    /// </summary>
    public record GetStats : BaseResponse
    {
        /// <summary>
        /// Current CPU usage in percent
        /// </summary>
        [JsonProperty("cpuUsage")]
        public double CpuUsage { get; set; }
        /// <summary>
        /// Amount of memory in MB currently being used by OBS
        /// </summary>
        [JsonProperty("memoryUsage")]
        public double MemoryUsage { get; set; }
        /// <summary>
        /// Available disk space on the device being used for recording storage
        /// </summary>
        [JsonProperty("availableDiskSpace")]
        public double AvailableDiskSpace { get; set; }
        /// <summary>
        /// Current FPS being rendered
        /// </summary>
        [JsonProperty("activeFps")]
        public double ActiveFps { get; set; }
        /// <summary>
        /// Average time in milliseconds that OBS is taking to render a frame
        /// </summary>
        [JsonProperty("averageFrameRenderTime")]
        public double AverageFrameRenderTime { get; set; }
        /// <summary>
        /// Number of frames skipped by OBS in the render thread
        /// </summary>
        [JsonProperty("renderSkippedFrames")]
        public uint RenderSkippedFrames { get; set; }
        /// <summary>
        /// Total number of frames outputted by the render thread
        /// </summary>
        [JsonProperty("renderTotalFrames")]
        public uint RenderTotalFrames { get; set; }
        /// <summary>
        /// Number of frames skipped by OBS in the output thread
        /// </summary>
        [JsonProperty("outputSkippedFrames")]
        public uint OutputSkippedFrames { get; set; }
        /// <summary>
        /// Total number of frames outputted by the output thread
        /// </summary>
        [JsonProperty("outputTotalFrames")]
        public uint OutputTotalFrames { get; set; }
        /// <summary>
        /// Total number of messages received by obs-websocket from the client
        /// </summary>
        [JsonProperty("webSocketSessionIncomingMessages")]
        public ulong WebSocketSessionIncomingMessages { get; set; }
        /// <summary>
        /// Total number of messages sent by obs-websocket to the client
        /// </summary>
        [JsonProperty("webSocketSessionOutgoingMessages")]
        public ulong WebSocketSessionOutgoingMessages { get; set; }
    }

    /// <summary>
    /// Broadcasts a <see cref="Events.CustomEvent"/> to all WebSocket clients. Receivers are clients which are identified and subscribed.
    /// </summary>
    public record BroadcastCustomEvent : BaseResponse
    { 
        
    }

    /// <summary>
    /// Call a request registered to a vendor.
    /// </summary>
    public record CallVendorRequest : BaseResponse
    {
        /// <summary>
        /// Echoed of vendorName
        /// </summary>
        [JsonProperty("vendorName")]
        public string VendorName { get; set; }
        /// <summary>
        /// Echoed of requestType
        /// </summary>
        [JsonProperty("requestType")]
        public string RequestType { get; set; }
        /// <summary>
        /// Object containing appropriate response data. {} if request does not provide any response data
        /// </summary>
        [JsonProperty("responseData")]
        public object ResponseData { get; set; }
    }

    /// <summary>
    /// Gets an array of all hotkey names in OBS.
    /// </summary>
    public record GetHotkeyList : BaseResponse
    {
        /// <summary>
        /// Array of hotkey names
        /// </summary>
        [JsonProperty("hotkeys")]
        public List<string> Hotkeys { get; set; }
    }

    /// <summary>
    /// Triggers a hotkey using its name. See <see cref="GetHotkeyList"/>.
    /// </summary>
    public record TriggerHotkeyByName : BaseResponse
    {
    
    }

    /// <summary>
    /// Triggers a hotkey using a sequence of keys.
    /// </summary>
    public record TriggerHotkeyByKeySequence : BaseResponse
    { 
    
    }

    /// <summary>
    /// Sleeps for a time duration or number of frames. Only available in request batches with types SERIAL_REALTIME or SERIAL_FRAME.
    /// </summary>
    public record Sleep : BaseResponse
    { 
    
    }
}
