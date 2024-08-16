using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ObsWebSocketSharp.Objs.Responses;

public static partial class Response
{
    /// <summary>
    /// Gets an array of all inputs in OBS.
    /// </summary>
    public record GetInputList : BaseResponse
    {
        [JsonProperty("inputs")]
        public List<object> Inputs { get; set; }
    }

    /// <summary>
    /// Gets an array of all available input kinds in OBS.
    /// </summary>
    public record GetInputKindList : BaseResponse
    {
        /// <summary>
        /// Array of input kinds
        /// </summary>
        [JsonProperty("inputKinds")]
        public List<string> InputKinds { get; set; }
    }

    /// <summary>
    /// Gets the names of all special inputs.
    /// </summary>
    public record GetSpecialInputs : BaseResponse
    {
        /// <summary>
        /// Name of the Desktop Audio input
        /// </summary>
        [JsonProperty("desktop1")]
        public string Desktop1 { get; set; }
        /// <summary>
        /// Name of the Desktop Audio 2 input
        /// </summary>
        [JsonProperty("desktop2")]
        public string Desktop2 { get; set; }
        /// <summary>
        /// Name of the Mic/Auxiliary Audio input
        /// </summary>
        [JsonProperty("mic1")]
        public string Mic1 { get; set; }
        /// <summary>
        /// Name of the Mic/Auxiliary Audio 2 input
        /// </summary>
        [JsonProperty("mic2")]
        public string Mic2 { get; set; }
        /// <summary>
        /// Name of the Mic/Auxiliary Audio 3 input
        /// </summary>
        [JsonProperty("mic3")]
        public string Mic3 { get; set; }
        /// <summary>
        /// Name of the Mic/Auxiliary Audio 4 input
        /// </summary>
        [JsonProperty("mic4")]
        public string Mic4 { get; set; }
    }

    /// <summary>
    /// Creates a new input, adding it as a scene item to the specified scene.
    /// </summary>
    public record CreateInput : BaseResponse
    {
        /// <summary>
        /// UUID of the newly created input
        /// </summary>
        [JsonProperty("inputUuid")]
        public string InputUuid { get; set; }
        /// <summary>
        /// ID of the newly created scene item
        /// </summary>
        [JsonProperty("sceneItemId")]
        public long SceneItemId { get; set; }
    }

    /// <summary>
    /// Removes an existing input.
    /// </summary>
    public record RemoveInput : BaseResponse
    { 
        
    }

    /// <summary>
    /// Sets the name of an input (rename).
    /// </summary>
    public record SetInputName : BaseResponse
    { 
    
    }

    /// <summary>
    /// Gets the default settings for an input kind.
    /// </summary>
    public record GetInputDefaultSettings : BaseResponse
    {
        /// <summary>
        /// Object of default settings for the input kind
        /// </summary>
        [JsonProperty("defaultInputSettings")]
        public object DefaultInputSettings { get; set; }
    }

    /// <summary>
    /// Gets the settings of an input.
    /// </summary>
    public record GetInputSettings : BaseResponse
    {
        /// <summary>
        /// Object of settings for the input
        /// </summary>
        [JsonProperty("inputSettings")]
        public object InputSettings { get; set; }
        /// <summary>
        /// The kind of the input
        /// </summary>
        [JsonProperty("inputKind")]
        public string InputKind { get; set; }
    }

    /// <summary>
    /// Sets the settings of an input.
    /// </summary>
    public record SetInputSettings : BaseResponse
    { 
        
    }

    /// <summary>
    /// Gets the audio mute state of an input.
    /// </summary>
    public record GetInputMute : BaseResponse
    {
        /// <summary>
        /// Whether the input is muted
        /// </summary>
        [JsonProperty("inputMuted")]
        public bool InputMuted { get; set; }
    }

    /// <summary>
    /// Sets the audio mute state of an input.
    /// </summary>
    public record SetInputMute : BaseResponse
    { 
        
    }

    /// <summary>
    /// Toggles the audio mute state of an input.
    /// </summary>
    public record ToggleInputMute : BaseResponse
    {
        /// <summary>
        /// Whether the input has been muted or unmuted
        /// </summary>
        [JsonProperty("inputMuted")]
        public bool InputMuted { get; set; }
    }

    /// <summary>
    /// Gets the current volume setting of an input.
    /// </summary>
    public record GetInputVolume : BaseResponse
    {
        /// <summary>
        /// Volume setting in mul
        /// </summary>
        [JsonProperty("inputVolumeMul")]
        public float InputVolumeMul { get; set; }
        /// <summary>
        /// Volume setting in dB
        /// </summary>
        [JsonProperty("inputVolumeDb")]
        public float InputVolumeDb { get; set; }
    }

    /// <summary>
    /// Sets the volume setting of an input.
    /// </summary>
    public record SetInputVolume : BaseResponse
    { 
        
    }

    /// <summary>
    /// Gets the audio balance of an input.
    /// </summary>
    public record GetInputAudioBalance : BaseResponse
    {
        /// <summary>
        /// Audio balance value from 0.0-1.0
        /// </summary>
        [JsonProperty("inputAudioBalance")]
        public float InputAudioBalance { get; set; }
    }

    /// <summary>
    /// Sets the audio balance of an input.
    /// </summary>
    public record SetInputAudioBalance : BaseResponse
    { 
        
    }

    /// <summary>
    /// Gets the audio sync offset of an input.
    /// </summary>
    public record GetInputAudioSyncOffset : BaseResponse
    {
        /// <summary>
        /// Audio sync offset in milliseconds
        /// </summary>
        [JsonProperty("inputAudioSyncOffset")]
        public long InputAudioSyncOffset { get; set; }
    }

    /// <summary>
    /// Sets the audio sync offset of an input.
    /// </summary>
    public record SetInputAudioSyncOffset : BaseResponse
    { 
        
    }

    /// <summary>
    /// Gets the audio monitor type of an input.
    /// </summary>
    public record GetInputAudioMonitorType : BaseResponse
    {
        /// <summary>
        /// Audio monitor type
        /// </summary>
        [JsonProperty("monitorType")]
        public string MonitorType { get; set; }
    }

    /// <summary>
    /// Sets the audio monitor type of an input.
    /// </summary>
    public record SetInputAudioMonitorType : BaseResponse
    { 
    
    }

    /// <summary>
    /// Gets the enable state of all audio tracks of an input.
    /// </summary>
    public record GetInputAudioTracks : BaseResponse
    {
        /// <summary>
        /// Object of audio tracks and associated enable states
        /// </summary>
        [JsonProperty("inputAudioTracks")]
        public object InputAudioTracks { get; set; }
    }
}
