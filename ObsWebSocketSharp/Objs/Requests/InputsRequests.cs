using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ObsWebSocketSharp.Objs.Requests;

public static partial class Request
{
    public record GetInputList : BaseRequest
    {
        /// <summary>
        /// Restrict the array to only inputs of the specified kind
        /// </summary>
        [JsonProperty("inputKind")]
        public string? InputKind { get; set; }
    }

    public record GetInputKindList : BaseRequest
    {
        /// <summary>
        /// True == Return all kinds as unversioned, False == Return with version suffixes (if available)
        /// </summary>
        [JsonProperty("unversioned")]
        public bool? Unversioned { get; set; }
    }

    public record GetSpecialInputs : BaseRequest
    { 
    
    }

    public record CreateInput : BaseRequest
    {
        /// <summary>
        /// Name of the scene to add the input to as a scene item
        /// </summary>
        [JsonProperty("sceneName")]
        public string? SceneName { get; set; }
        /// <summary>
        /// UUID of the scene to add the input to as a scene item
        /// </summary>
        [JsonProperty("sceneUuid")]
        public string? SceneUuid { get; set; }
        /// <summary>
        /// Name of the new input to created
        /// </summary>
        [JsonProperty("inputName")]
        public string InputName { get; set; }
        /// <summary>
        /// The kind of input to be created
        /// </summary>
        [JsonProperty("inputKind")]
        public string InputKind { get; set; }
        /// <summary>
        /// Settings object to initialize the input with
        /// </summary>
        [JsonProperty("inputSettings")]
        public object? InputSettings { get; set; }
        /// <summary>
        /// Whether to set the created scene item to enabled or disabled
        /// </summary>
        [JsonProperty("sceneItemEnabled")]
        public bool? SceneItemEnabled { get; set; } = true;
    }

    public record RemoveInput : BaseRequest
    {
        /// <summary>
        /// Name of the input to remove
        /// </summary>
        [JsonProperty("inputName")]
        public string? InputName { get; set; }
        /// <summary>
        /// UUID of the input to remove
        /// </summary>
        [JsonProperty("inputUuid")]
        public string? InputUuid { get; set; }
    }

    public record SetInputName : BaseRequest
    {
        /// <summary>
        /// Current input name 
        /// </summary>
        [JsonProperty("inputName")]
        public string? InputName { get; set; }
        /// <summary>
        /// Current input UUID
        /// </summary>
        [JsonProperty("inputUuid")]
        public string? InputUuid { get; set; }
        /// <summary>
        /// New name for the input
        /// </summary>
        [JsonProperty("newInputName")]
        public string NewInputName { get; set; }
    }

    public record GetInputDefaultSettings : BaseRequest
    {
        /// <summary>
        /// Input kind to get the default settings for
        /// </summary>
        [JsonProperty("inputKind")]
        public string InputKind { get; set; }
    }

    public record GetInputSettings : BaseRequest
    {
        /// <summary>
        /// Name of the input to get the settings of
        /// </summary>
        [JsonProperty("inputName")]
        public string? InputName { get; set; }
        /// <summary>
        /// UUID of the input to get the settings of
        /// </summary>
        [JsonProperty("inputUuid")]
        public string? InputUuid { get; set; }
    }

    public record SetInputSettings : BaseRequest
    {
        /// <summary>
        /// Name of the input to set the settings of
        /// </summary>
        [JsonProperty("inputName")]
        public string? InputName { get; set; }
        /// <summary>
        /// UUID of the input to set the settings of
        /// </summary>
        [JsonProperty("inputUuid")]
        public string? InputUuid { get; set; }
        /// <summary>
        /// Object of settings to apply
        /// </summary>
        [JsonProperty("inputSettings")]
        public object? InputSettings { get; set; }
        /// <summary>
        /// True == apply the settings on top of existing ones, False == reset the input to its defaults, then apply settings.
        /// </summary>
        [JsonProperty("overlay")]
        public bool? Overlay { get; set; }
    }

    public record GetInputMute : BaseRequest
    {
        /// <summary>
        /// Name of input to get the mute state of
        /// </summary>
        [JsonProperty("inputName")]
        public string? InputName { get; set; }
        /// <summary>
        /// UUID of input to get the mute state of
        /// </summary>
        [JsonProperty("inputUuid")]
        public string? InputUuid { get; set; }
    }

    public record SetInputMute : BaseRequest
    {
        /// <summary>
        /// Name of input to get the mute state of
        /// </summary>
        [JsonProperty("inputName")]
        public string? InputName { get; set; }
        /// <summary>
        /// UUID of input to get the mute state of
        /// </summary>
        [JsonProperty("inputUuid")]
        public string? InputUuid { get; set; }
        /// <summary>
        /// UUID of input to get the mute state of
        /// </summary>
        [JsonProperty("inputMuted")]
        public bool InputMuted { get; set; }
    }

    public record ToggleInputMute : BaseRequest
    {
        /// <summary>
        /// Name of the input to toggle the mute state of
        /// </summary>
        [JsonProperty("inputName")]
        public string? InputName { get; set; }
        /// <summary>
        /// UUID of the input to toggle the mute state of
        /// </summary>
        [JsonProperty("inputUuid")]
        public string? InputUuid { get; set; }
    }

    public record GetInputVolume : BaseRequest
    {
        /// <summary>
        /// Name of the input to get the volume of
        /// </summary>
        [JsonProperty("inputName")]
        public string? InputName { get; set; }
        /// <summary>
        /// UUID of the input to get the volume of
        /// </summary>
        [JsonProperty("inputUuid")]
        public string? InputUuid { get; set; }
    }

    public record SetInputVolume : BaseRequest
    {
        /// <summary>
        /// Name of the input to set the volume of
        /// </summary>
        [JsonProperty("inputName")]
        public string? InputName { get; set; }
        /// <summary>
        /// UUID of the input to set the volume of
        /// </summary>
        [JsonProperty("inputUuid")]
        public string? InputUuid { get; set; }
        /// <summary>
        /// Volume setting in mul >= 0, &lt;= 20
        /// </summary>
        [JsonProperty("inputVolumeMul")]
        public float? InputVolumeMul { get; set; }
        /// <summary>
        /// Volume setting in dB >= -100, &lt;= 26
        /// </summary>
        [JsonProperty("inputVolumeDb")]
        public float? InputVolumeDb { get; set; }
    }

    public record GetInputAudioBalance : BaseRequest
    {
        /// <summary>
        /// Name of the input to get the audio balance of
        /// </summary>
        [JsonProperty("inputName")]
        public string? InputName { get; set; }
        /// <summary>
        /// UUID of the input to get the audio balance of
        /// </summary>
        [JsonProperty("inputUuid")]
        public string? InputUuid { get; set; }
    }

    public record SetInputAudioBalance : BaseRequest
    {
        /// <summary>
        /// Name of the input to set the audio balance of
        /// </summary>
        [JsonProperty("inputName")]
        public string? InputName { get; set; }
        /// <summary>
        /// UUID of the input to set the audio balance of
        /// </summary>
        [JsonProperty("inputUuid")]
        public string? InputUuid { get; set; }
        /// <summary>
        /// New audio balance value >= 0.0, &lt;= 1.0
        /// </summary>
        [JsonProperty("inputAudioBalance")]
        public float InputAudioBalance { get; set; }
    }

    public record GetInputAudioSyncOffset : BaseRequest
    {
        /// <summary>
        /// Name of the input to get the audio sync offset of
        /// </summary>
        [JsonProperty("inputName")]
        public string? InputName { get; set; }
        /// <summary>
        /// UUID of the input to get the audio sync offset of
        /// </summary>
        [JsonProperty("inputUuid")]
        public string? InputUuid { get; set; }
    }

    public record SetInputAudioSyncOffset : BaseRequest
    {
        /// <summary>
        /// Name of the input to set the audio sync offset of
        /// </summary>
        [JsonProperty("inputName")]
        public string? InputName { get; set; }
        /// <summary>
        /// UUID of the input to set the audio sync offset of
        /// </summary>
        [JsonProperty("inputUuid")]
        public string? InputUuid { get; set; }
        /// <summary>
        /// New audio sync offset in milliseconds >= -950, &lt;= 20000
        /// </summary>
        [JsonProperty("inputAudioSyncOffset")]
        public long InputAudioSyncOffset { get; set; }
    }

    public record GetInputAudioMonitorType : BaseRequest
    {
        /// <summary>
        /// Name of the input to get the audio monitor type of
        /// </summary>
        [JsonProperty("inputName")]
        public string? InputName { get; set; }
        /// <summary>
        /// UUID of the input to get the audio monitor type of
        /// </summary>
        [JsonProperty("inputUuid")]
        public string? InputUuid { get; set; }
    }

    public record SetInputAudioMonitorType : BaseRequest
    {
        /// <summary>
        /// Name of the input to set the audio monitor type of
        /// </summary>
        [JsonProperty("inputName")]
        public string? InputName { get; set; }
        /// <summary>
        /// UUID of the input to set the audio monitor type of
        /// </summary>
        [JsonProperty("inputUuid")]
        public string? InputUuid { get; set; }
        /// <summary>
        /// Audio monitor type
        /// </summary>
        [JsonProperty("monitorType")]
        public string MonitorType { get; set; }
    }

    public record GetInputAudioTracks : BaseRequest 
    {
        /// <summary>
        /// Name of the input
        /// </summary>
        [JsonProperty("inputName")]
        public string? InputName { get; set; }
        /// <summary>
        /// UUID of the input
        /// </summary>
        [JsonProperty("inputUuid")]
        public string? InputUuid { get; set; }
    }
}
