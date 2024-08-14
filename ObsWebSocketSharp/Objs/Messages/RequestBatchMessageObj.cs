using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ObsWebSocketSharp.Objs.Messages;

public record RequestBatchMessageObj
{
    [JsonProperty("requestId")]
    public string RequestId { get; set; }
    [JsonProperty("haltOnFailure")]
    public bool HaltOnFailure { get; set; }
    [JsonProperty("executionType")]
    public RequestBatchExecutionType ExecutionType { get; set; }
    [JsonProperty("requests")]
    public object Requests { get; set; }
}
