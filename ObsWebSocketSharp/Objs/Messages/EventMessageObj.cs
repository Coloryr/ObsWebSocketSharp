using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ObsWebSocketSharp.Objs.Messages;

public record EventMessageObj
{
    [JsonProperty("eventType")]
    public string EventType { get; set; }
    [JsonProperty("eventIntent")]
    public EventSubscription EventIntent { get; set; }
    [JsonProperty("eventData")]
    public object EventData { get; set; }
}
