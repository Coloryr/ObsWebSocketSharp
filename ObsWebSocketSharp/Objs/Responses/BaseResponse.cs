using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ObsWebSocketSharp.Objs.Responses;

public abstract record BaseResponse
{
    /// <summary>
    /// Response status
    /// </summary>
    [JsonIgnore]
    public RequestStatusObj RequestStatus { get; set; }
}
