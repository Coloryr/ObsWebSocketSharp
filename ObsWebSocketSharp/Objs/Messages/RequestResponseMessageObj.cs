using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ObsWebSocketSharp.Objs.Messages;

public record RequestResponseMessageObj
{
    [JsonProperty("requestType")]
    public string RequestType { get; set; }
    [JsonProperty("requestId")]
    public string RequestId { get; set; }
    [JsonProperty("requestStatus")]
    public RequestStatusObj RequestStatus { get; set; }
    [JsonProperty("responseData")]
    public object ResponseData { get; set; }
}
