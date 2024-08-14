using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ObsWebSocketSharp.Objs;

public record AuthenticationObj
{
    [JsonProperty("challenge")]
    public string Challenge { get; set; }
    [JsonProperty("salt")]
    public string Salt { get; set; }
}
