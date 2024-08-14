using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ObsWebSocketSharp.Objs.Messages;

public record RequestBatchResponseMessageObj
{
    [JsonProperty("requestId")]
    public string RequestId { get; set; }
    [JsonProperty("results")]
    public object Results { get; set; }
}
