using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ObsWebSocketSharp.Objs.Events;

public abstract record InputBase : BaseEvent
{
    /// <summary>
    /// Name of the input
    /// </summary>
    [JsonProperty("inputName")]
    public string InputName { get; set; }
    /// <summary>
    /// UUID of the input
    /// </summary>
    [JsonProperty("inputUuid")]
    public string InputUuid { get; set; }
}

/// <summary>
/// An input has been created.
/// </summary>
public record InputCreated : InputBase
{
    /// <summary>
    /// The kind of the input
    /// </summary>
    [JsonProperty("inputKind")]
    public string InputKind { get; set; }
    /// <summary>
    /// The unversioned kind of input (aka no _v2 stuff)
    /// </summary>
    [JsonProperty("unversionedInputKind")]
    public string UnversionedInputKind { get; set; }
    /// <summary>
    /// The settings configured to the input when it was created
    /// </summary>
    [JsonProperty("inputSettings")]
    public object InputSettings { get; set; }
    /// <summary>
    /// The default settings for the input
    /// </summary>
    [JsonProperty("defaultInputSettings")]
    public object DefaultInputSettings { get; set; }
}

/// <summary>
/// An input has been removed.
/// </summary>
public record InputRemoved : InputBase
{
    
}

/// <summary>
/// The name of an input has changed.
/// </summary>
public record InputNameChanged : BaseEvent
{
    /// <summary>
    /// New name of the input
    /// </summary>
    [JsonProperty("inputName")]
    public string InputName { get; set; }
    /// <summary>
    /// UUID of the input
    /// </summary>
    [JsonProperty("inputUuid")]
    public string InputUuid { get; set; }
    /// <summary>
    /// Old name of the input
    /// </summary>
    [JsonProperty("oldInputName")]
    public string OldInputName { get; set; }
}

/// <summary>
/// An input's settings have changed (been updated).
/// 
/// Note: On some inputs, changing values in the properties dialog will cause an immediate update. Pressing the "Cancel" button will revert the settings, resulting in another event being fired.
/// </summary>
public record InputSettingsChanged : InputBase
{
    /// <summary>
    /// New settings object of the input
    /// </summary>
    [JsonProperty("inputSettings")]
    public object InputSettings { get; set; }
}

/// <summary>
/// An input's active state has changed.
/// 
/// When an input is active, it means it's being shown by the program feed.
/// </summary>
public record InputActiveStateChanged : InputBase
{
    /// <summary>
    /// Whether the input is active
    /// </summary>
    [JsonProperty("videoActive")]
    public bool VideoActive { get; set; }
}

/// <summary>
/// An input's show state has changed.
/// 
/// When an input is showing, it means it's being shown by the preview or a dialog.
/// </summary>
public record InputShowStateChanged : InputBase
{
    /// <summary>
    /// Whether the input is showing
    /// </summary>
    [JsonProperty("videoShowing")]
    public bool VideoShowing { get; set; }
}

/// <summary>
/// An input's mute state has changed.
/// </summary>
public record InputMuteStateChanged : InputBase
{
    /// <summary>
    /// Whether the input is muted
    /// </summary>
    [JsonProperty("inputMuted")]
    public bool InputMuted { get; set; }
}

/// <summary>
/// An input's volume level has changed.
/// </summary>
public record InputVolumeChanged : InputBase
{
    /// <summary>
    /// New volume level multiplier
    /// </summary>
    [JsonProperty("inputVolumeMul")]
    public float InputVolumeMul { get; set; }
    /// <summary>
    /// New volume level in dB
    /// </summary>
    [JsonProperty("inputVolumeDb")]
    public float InputVolumeDb { get; set; }
}

/// <summary>
/// The audio balance value of an input has changed.
/// </summary>
public record InputAudioBalanceChanged : InputBase
{
    /// <summary>
    /// New audio balance value of the input
    /// </summary>
    [JsonProperty("inputAudioBalance")]
    public float InputAudioBalance { get; set; }
}

/// <summary>
/// The sync offset of an input has changed.
/// </summary>
public record InputAudioSyncOffsetChanged : InputBase
{
    /// <summary>
    /// New sync offset in milliseconds
    /// </summary>
    [JsonProperty("inputAudioSyncOffset")]
    public float InputAudioSyncOffset { get; set; }
}

/// <summary>
/// The audio tracks of an input have changed.
/// </summary>
public record InputAudioTracksChanged : InputBase
{
    /// <summary>
    /// Object of audio tracks along with their associated enable states
    /// </summary>
    [JsonProperty("inputAudioTracks")]
    public object InputAudioTracks { get; set; }
}

/// <summary>
/// The monitor type of an input has changed.
/// </summary>
public record InputAudioMonitorTypeChanged : InputBase
{
    /// <summary>
    /// New monitor type of the input
    /// 
    /// See <see cref="MonitorTypeName" />
    /// </summary>
    [JsonProperty("monitorType")]
    public string MonitorType { get; set; }
}

/// <summary>
/// A high-volume event providing volume levels of all active inputs every 50 milliseconds.
/// </summary>
public record InputVolumeMeters : BaseEvent
{
    /// <summary>
    /// Array of active inputs with their associated volume levels
    /// </summary>
    [JsonProperty("inputs")]
    public List<object> Inputs { get; set; }
}