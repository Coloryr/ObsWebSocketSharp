using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ObsWebSocketSharp.Objs.Events;

/// <summary>
/// Studio mode has been enabled or disabled.
/// </summary>
public record StudioModeStateChanged : BaseEvent
{
    /// <summary>
    /// True == Enabled, False == Disabled
    /// </summary>
    [JsonProperty("studioModeEnabled")]
    public bool StudioModeEnabled { get; set; }
}

/// <summary>
/// A screenshot has been saved.
/// 
/// Note: Triggered for the screenshot feature available in Settings -> Hotkeys -> Screenshot Output ONLY. Applications using Get/SaveSourceScreenshot should implement a CustomEvent if this kind of inter-client communication is desired.
/// </summary>
public record ScreenshotSaved : BaseEvent
{
    /// <summary>
    /// Path of the saved image file
    /// </summary>
    [JsonProperty("savedScreenshotPath")]
    public string SavedScreenshotPath { get; set; }
}