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
    /// Gets the value of a "slot" from the selected persistent data realm.
    /// </summary>
    public record GetPersistentData : BaseResponse
    {
        /// <summary>
        /// Value associated with the slot. null if not set
        /// </summary>
        [JsonProperty("slotValue")]
        public object SlotValue { get; set; }
    }

    /// <summary>
    /// Sets the value of a "slot" from the selected persistent data realm.
    /// </summary>
    public record SetPersistentData : BaseResponse
    { 
        
    }

    /// <summary>
    /// Gets an array of all scene collections
    /// </summary>
    public record GetSceneCollectionList : BaseResponse
    {
        /// <summary>
        /// The name of the current scene collection
        /// </summary>
        [JsonProperty("currentSceneCollectionName")]
        public string CurrentSceneCollectionName { get; set; }
        /// <summary>
        /// Array of all available scene collections
        /// </summary>
        [JsonProperty("sceneCollections")]
        public List<string> SceneCollections { get; set; }
    }

    /// <summary>
    /// Switches to a scene collection.
    /// </summary>
    public record SetCurrentSceneCollection : BaseResponse
    { 
        
    }

    /// <summary>
    /// Creates a new scene collection, switching to it in the process.
    /// </summary>
    public record CreateSceneCollection : BaseResponse
    { 
    
    }

    /// <summary>
    /// Gets an array of all profiles
    /// </summary>
    public record GetProfileList : BaseResponse
    {
        /// <summary>
        /// The name of the current profile
        /// </summary>
        [JsonProperty("currentProfileName")]
        public string CurrentProfileName { get; set; }
        /// <summary>
        /// Array of all available profiles
        /// </summary>
        [JsonProperty("profiles")]
        public List<string> Profiles { get; set; }
    }

    /// <summary>
    /// Switches to a profile.
    /// </summary>
    public record SetCurrentProfile : BaseResponse
    { 
        
    }

    /// <summary>
    /// Creates a new profile, switching to it in the process
    /// </summary>
    public record CreateProfile : BaseResponse
    { 
    
    }

    /// <summary>
    /// Removes a profile. If the current profile is chosen, it will change to a different profile first.
    /// </summary>
    public record RemoveProfile : BaseResponse 
    {
        
    }

    /// <summary>
    /// Gets a parameter from the current profile's configuration.
    /// </summary>
    public record GetProfileParameter : BaseResponse
    {
        /// <summary>
        /// Value associated with the parameter. null if not set and no default
        /// </summary>
        [JsonProperty("parameterValue")]
        public string ParameterValue { get; set; }
        /// <summary>
        /// Default value associated with the parameter. null if no default
        /// </summary>
        [JsonProperty("defaultParameterValue")]
        public string DefaultParameterValue { get; set; }
    }

    /// <summary>
    /// Sets the value of a parameter in the current profile's configuration.
    /// </summary>
    public record SetProfileParameter : BaseResponse
    { 
    
    }

    /// <summary>
    /// Gets the current video settings.
    /// </summary>
    public record GetVideoSettings : BaseResponse
    {
        /// <summary>
        /// Numerator of the fractional FPS value
        /// </summary>
        [JsonProperty("fpsNumerator")]
        public uint FpsNumerator { get; set; }
        /// <summary>
        /// Denominator of the fractional FPS value
        /// </summary>
        [JsonProperty("fpsDenominator")]
        public uint FpsDenominator { get; set; }
        /// <summary>
        /// Width of the base (canvas) resolution in pixels
        /// </summary>
        [JsonProperty("baseWidth")]
        public uint BaseWidth { get; set; }
        /// <summary>
        /// Height of the base (canvas) resolution in pixels
        /// </summary>
        [JsonProperty("baseHeight")]
        public uint BaseHeight { get; set; }
        /// <summary>
        /// Width of the output resolution in pixels
        /// </summary>
        [JsonProperty("outputWidth")]
        public uint OutputWidth { get; set; }
        /// <summary>
        /// Height of the output resolution in pixels
        /// </summary>
        [JsonProperty("outputHeight")]
        public uint OutputHeight { get; set; }
    }

    /// <summary>
    /// Sets the current video settings.
    /// </summary>
    public record SetVideoSettings : BaseResponse
    { 
        
    }

    /// <summary>
    /// Gets the current stream service settings (stream destination).
    /// </summary>
    public record GetStreamServiceSettings : BaseResponse
    {
        /// <summary>
        /// Stream service type, like rtmp_custom or rtmp_common
        /// </summary>
        [JsonProperty("streamServiceType")]
        public string StreamServiceType { get; set; }
        /// <summary>
        /// Stream service settings
        /// </summary>
        [JsonProperty("streamServiceSettings")]
        public object StreamServiceSettings { get; set; }
    }

    /// <summary>
    /// Sets the current stream service settings (stream destination).
    /// </summary>
    public record SetStreamServiceSettings : BaseResponse
    { 
    
    }

    /// <summary>
    /// Gets the current directory that the record output is set to.
    /// </summary>
    public record GetRecordDirectory : BaseResponse
    {
        /// <summary>
        /// Output directory
        /// </summary>
        [JsonProperty("recordDirectory")]
        public string RecordDirectory { get; set; }
    }

    /// <summary>
    /// Sets the current directory that the record output writes files to.
    /// </summary>
    public record SetRecordDirectory : BaseResponse
    { 
    
    }
}
