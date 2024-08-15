using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ObsWebSocketSharp.Objs.Events;

public abstract record BaseSceneTransition : BaseEvent
{
    /// <summary>
    /// Scene transition name
    /// </summary>
    [JsonProperty("transitionName")]
    public string TransitionName { get; set; }
    /// <summary>
    /// Scene transition UUID
    /// </summary>
    [JsonProperty("transitionUuid")]
    public string TransitionUuid { get; set; }
}

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

/// <summary>
/// The current scene transition duration has changed.
/// </summary>
public record CurrentSceneTransitionDurationChanged : BaseEvent
{
    /// <summary>
    /// Transition duration in milliseconds
    /// </summary>
    [JsonProperty("transitionDuration")]
    public float TransitionDuration { get; set; }
}

/// <summary>
/// A scene transition has started.
/// </summary>
public record SceneTransitionStarted : BaseSceneTransition
{
    
}

/// <summary>
/// A scene transition has completed fully.
/// 
/// Note: Does not appear to trigger when the transition is interrupted by the user.
/// </summary>
public record SceneTransitionEnded : BaseSceneTransition
{

}

/// <summary>
/// A scene transition's video has completed fully.
/// 
/// Useful for stinger transitions to tell when the video actually ends. <see cref="SceneTransitionEnded"/> only signifies the cut point, not the completion of transition playback.
/// 
/// Note: Appears to be called by every transition, regardless of relevance.
/// </summary>
public record SceneTransitionVideoEnded : BaseSceneTransition
{ 
    
}