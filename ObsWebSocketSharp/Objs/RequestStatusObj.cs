using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ObsWebSocketSharp.Objs;

public record RequestStatusObj
{
    [JsonProperty("result")]
    public bool Result { get; set; }
    [JsonProperty("code")]
    public RequestStatus Code { get; set; }
    [JsonProperty("comment")]
    public string Comment { get; set; }
}
