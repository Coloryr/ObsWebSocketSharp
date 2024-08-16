using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ObsWebSocketSharp.Objs.Requests;

public static partial class Request
{
    public record GetPersistentData : BaseRequest
    {
        /// <summary>
        /// The data realm to select. OBS_WEBSOCKET_DATA_REALM_GLOBAL or OBS_WEBSOCKET_DATA_REALM_PROFILE
        /// </summary>
        [JsonProperty("realm")]
        public string Realm { get; set; }
        /// <summary>
        /// The name of the slot to retrieve data from
        /// </summary>
        [JsonProperty("slotName")]
        public string SlotName { get; set; }
    }

    public record SetPersistentData : BaseRequest
    {
        /// <summary>
        /// The data realm to select. OBS_WEBSOCKET_DATA_REALM_GLOBAL or OBS_WEBSOCKET_DATA_REALM_PROFILE
        /// </summary>
        [JsonProperty("realm")]
        public string Realm { get; set; }
        /// <summary>
        /// The name of the slot to retrieve data from
        /// </summary>
        [JsonProperty("slotName")]
        public string SlotName { get; set; }
        /// <summary>
        /// The value to apply to the slot
        /// </summary>
        [JsonProperty("slotValue")]
        public object SlotValue { get; set; }
    }

    public record GetSceneCollectionList : BaseRequest
    { 
        
    }

    public record SetCurrentSceneCollection : BaseRequest
    {
        /// <summary>
        /// Name of the scene collection to switch to
        /// </summary>
        [JsonProperty("sceneCollectionName")]
        public string SceneCollectionName { get; set; }
    }

    public record CreateSceneCollection : BaseRequest
    {
        /// <summary>
        /// Name for the new scene collection
        /// </summary>
        [JsonProperty("sceneCollectionName")]
        public string SceneCollectionName { get; set; }
    }

    public record GetProfileList : BaseRequest
    { 
        
    }

    public record SetCurrentProfile : BaseRequest
    {
        /// <summary>
        /// Name of the profile to switch to
        /// </summary>
        [JsonProperty("profileName")]
        public string ProfileName { get; set; } 
    }

    public record CreateProfile : BaseRequest
    {
        /// <summary>
        /// Name for the new profile
        /// </summary>
        [JsonProperty("profileName")]
        public string ProfileName { get; set; }
    }

    public record RemoveProfile : BaseRequest
    {
        /// <summary>
        /// Name of the profile to remove
        /// </summary>
        [JsonProperty("profileName")]
        public string ProfileName { get; set; }
    }

    public record GetProfileParameter : BaseRequest
    {
        /// <summary>
        /// Category of the parameter to get
        /// </summary>
        [JsonProperty("parameterCategory")]
        public string ParameterCategory { get; set; }
        /// <summary>
        /// Name of the parameter to get
        /// </summary>
        [JsonProperty("parameterName")]
        public string ParameterName { get; set; }
    }

    public record SetProfileParameter : BaseRequest
    {
        /// <summary>
        /// Category of the parameter to set
        /// </summary>
        [JsonProperty("parameterCategory")]
        public string ParameterCategory { get; set; }
        /// <summary>
        /// Name of the parameter to set
        /// </summary>
        [JsonProperty("parameterName")]
        public string ParameterName { get; set; }
        /// <summary>
        /// Value of the parameter to set. Use `null` to delete
        /// </summary>
        [JsonProperty("parameterValue")]
        public string ParameterValue { get; set; }
    }

    public record GetVideoSettings : BaseRequest
    { 
        
    }

    public record SetVideoSettings : BaseRequest
    {
        /// <summary>
        /// Numerator of the fractional FPS value >= 1
        /// </summary>
        [JsonProperty("fpsNumerator")]
        public ulong? FpsNumerator { get; set; }
        /// <summary>
        /// Denominator of the fractional FPS value >= 1
        /// </summary>
        [JsonProperty("fpsDenominator")]
        public ulong? FpsDenominator { get; set; }
        /// <summary>
        /// Width of the base (canvas) resolution in pixels >= 1
        /// </summary>
        [JsonProperty("baseWidth")]
        public ulong? BaseWidth { get; set; }
        /// <summary>
        /// Height of the base (canvas) resolution in pixels >= 1
        /// </summary>
        [JsonProperty("baseHeight")]
        public ulong? BaseHeight { get; set; }
        /// <summary>
        /// Width of the output resolution in pixels >= 1, <= 4096
        /// </summary>
        [JsonProperty("outputWidth")]
        public ulong? OutputWidth { get; set; }
        /// <summary>
        /// Height of the output resolution in pixels >= 1, <= 4096
        /// </summary>
        [JsonProperty("outputHeight")]
        public ulong? OutputHeight { get; set; }
    }

    public record GetStreamServiceSettings : BaseRequest
    { 
        
    }

    public record SetStreamServiceSettings : BaseRequest
    {
        /// <summary>
        /// Type of stream service to apply. Example: rtmp_common or rtmp_custom
        /// </summary>
        [JsonProperty("streamServiceType")]
        public string StreamServiceType { get; set; }
        /// <summary>
        /// Settings to apply to the service
        /// </summary>
        [JsonProperty("streamServiceSettings")]
        public object StreamServiceSettings { get; set; }
    }

    public record GetRecordDirectory : BaseRequest
    { 
        
    }

    public record SetRecordDirectory : BaseRequest
    {
        /// <summary>
        /// Output directory
        /// </summary>
        [JsonProperty("recordDirectory")]
        public string RecordDirectory { get; set; }
    }
}
