using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ObsWebSocketSharp.Objs.Messages;

public record IdentifyMessageObj
{
    [JsonProperty("rpcVersion")]
    public int RpcVersion { get; set; }
    [JsonProperty("authentication")]
    public string Authentication { get; set; }
    [JsonProperty("eventSubscriptions")]
    public EventSubscription EventSubscriptions { get; set; }
}
