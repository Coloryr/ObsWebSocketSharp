using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ObsWebSocketSharp.Objs.Events;

public abstract record BaseMediaInputEvent : BaseEvent
{
    [JsonProperty("inputName")]
    public string InputName { get; set; }
    [JsonProperty("inputUuid")]
    public string InputUuid { get; set; }
}

/// <summary>
/// A media input has started playing.
/// </summary>
public record MediaInputPlaybackStarted : BaseMediaInputEvent
{
    
}

/// <summary>
/// A media input has finished playing.
/// </summary>
public record MediaInputPlaybackEnded : BaseMediaInputEvent
{
    
}

/// <summary>
/// 
/// </summary>
public record MediaInputActionTriggered : BaseMediaInputEvent
{
    /// <summary>
    /// Action performed on the input. See <see cref="ObsMediaInputAction" /> enum
    /// </summary>
    [JsonProperty("mediaAction")]
    public string MediaAction { get; set; }
}