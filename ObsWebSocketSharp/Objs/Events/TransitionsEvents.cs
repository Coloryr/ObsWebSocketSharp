using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ObsWebSocketSharp.Objs.Events;

/// <summary>
/// The current scene transition has changed.
/// </summary>
public record CurrentSceneTransitionChanged : BaseEvent
{
    /// <summary>
    /// Name of the new transition
    /// </summary>
    [JsonProperty("transitionName")]
    public string TransitionName { get; set; }
    /// <summary>
    /// UUID of the new transition
    /// </summary>
    [JsonProperty("transitionUuid")]
    public string TransitionUuid { get; set; }
}