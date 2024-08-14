using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ObsWebSocketSharp.Objs.Messages;

public record HelloMessageObj
{
    [JsonProperty("obsWebSocketVersion")]
    public string ObsWebSocketVersion { get; set; }
    [JsonProperty("rpcVersion")]
    public int RpcVersion { get; set; }
    [JsonProperty("authentication")]
    public AuthenticationObj Authentication { get; set; }
}
