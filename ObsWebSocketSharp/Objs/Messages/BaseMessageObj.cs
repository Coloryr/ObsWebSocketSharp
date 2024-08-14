using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ObsWebSocketSharp.Objs.Messages;

public record BaseMessageObj
{
    [JsonProperty("op")]
    public WebSocketOpCode OpCode { get; set; }
    [JsonProperty("d")]
    public object Data { get; set; }
}
