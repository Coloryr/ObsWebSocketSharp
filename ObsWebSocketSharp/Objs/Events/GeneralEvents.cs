using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ObsWebSocketSharp.Objs.Events;

/// <summary>
/// OBS has begun the shutdown process.
/// </summary>
public record ExitStarted : BaseEvent
{

}

/// <summary>
/// Custom event emitted by <see cref="Requests.Request.BroadcastCustomEvent" />.
/// </summary>
public record CustomEvent : BaseEvent
{
    [JsonProperty("eventData")]
    public object EventData { get; set; }
}

/// <summary>
/// An event has been emitted from a vendor.
/// 
/// A vendor is a unique name registered by a third-party plugin or script, which allows for custom requests and events to be added to obs-websocket. If a plugin or script implements vendor requests or events, documentation is expected to be provided with them.
/// </summary>
public record VendorEvent : BaseEvent
{
    [JsonProperty("vendorName")]
    public string VendorName { get; set; }
    [JsonProperty("eventType")]
    public string EventType { get; set; }
    [JsonProperty("eventData")]
    public object EventData { get; set; }
}
