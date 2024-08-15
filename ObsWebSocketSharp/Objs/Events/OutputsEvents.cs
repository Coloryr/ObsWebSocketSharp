using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ObsWebSocketSharp.Objs.Events;

public abstract record BaseOutputEvent : BaseEvent
{
    /// <summary>
    /// Whether the output is active
    /// </summary>
    [JsonProperty("outputActive")]
    public bool OutputActive { get; set; }
    /// <summary>
    /// The specific state of the output
    /// </summary>
    [JsonProperty("outputState")]
    public string OutputState { get; set; }
}

/// <summary>
/// The state of the stream output has changed.
/// </summary>
public record StreamStateChanged : BaseOutputEvent
{
  
}

/// <summary>
/// The state of the record output has changed.
/// </summary>
public record RecordStateChanged : BaseOutputEvent
{
    /// <summary>
    /// File name for the saved recording, if record stopped. null otherwise
    /// </summary>
    [JsonProperty("outputPath")]
    public string OutputPath { get; set; }
}

/// <summary>
/// The record output has started writing to a new file. For example, when a file split happens.
/// </summary>
public record RecordFileChanged : BaseEvent
{
    /// <summary>
    /// File name that the output has begun writing to
    /// </summary>
    [JsonProperty("newOutputPath")]
    public string NewOutputPath { get; set; }
}

/// <summary>
/// The state of the replay buffer output has changed.
/// </summary>
public record ReplayBufferStateChanged : BaseOutputEvent
{
    
}

/// <summary>
/// The state of the virtualcam output has changed.
/// </summary>
public record VirtualcamStateChanged : BaseOutputEvent
{ 
    
}

/// <summary>
/// The replay buffer has been saved.
/// </summary>
public record ReplayBufferSaved : BaseEvent
{
    /// <summary>
    /// Path of the saved replay file
    /// </summary>
    [JsonProperty("savedReplayPath")]
    public string SavedReplayPath { get; set; }
}