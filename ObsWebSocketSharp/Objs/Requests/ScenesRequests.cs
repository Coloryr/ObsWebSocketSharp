using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ObsWebSocketSharp.Objs.Requests;

public static partial class Request
{
    public record GetSceneList : BaseRequest
    { 
        
    }

    public record GetGroupList : BaseRequest
    { 
    
    }

    public record GetCurrentProgramScene : BaseRequest
    { 
        
    }

    public record SetCurrentProgramScene : BaseRequest
    {
        /// <summary>
        /// Scene name to set as the current program scene
        /// </summary>
        [JsonProperty("sceneName")]
        public string? SceneName { get; set; }
        /// <summary>
        /// Scene UUID to set as the current program scene
        /// </summary>
        [JsonProperty("sceneUuid")]
        public string? SceneUuid { get; set; }
    }

    public record GetCurrentPreviewScene : BaseRequest
    { 
        
    }

    public record SetCurrentPreviewScene : BaseRequest
    {
        /// <summary>
        /// Scene name to set as the current preview scene
        /// </summary>
        [JsonProperty("sceneName")]
        public string? SceneName { get; set; }
        /// <summary>
        /// Scene UUID to set as the current preview scene
        /// </summary>
        [JsonProperty("sceneUuid")]
        public string? SceneUuid { get; set; }
    }

    public record CreateScene : BaseRequest
    {
        /// <summary>
        /// Name for the new scene
        /// </summary>
        [JsonProperty("sceneName")]
        public string? SceneName { get; set; }
    }

    public record RemoveScene : BaseRequest
    {
        /// <summary>
        /// Name of the scene to remove
        /// </summary>
        [JsonProperty("sceneName")]
        public string? SceneName { get; set; }
        /// <summary>
        /// UUID of the scene to remove
        /// </summary>
        [JsonProperty("sceneUuid")]
        public string? SceneUuid { get; set; }
    }

    public record SetSceneName : BaseRequest
    {
        /// <summary>
        /// Name of the scene to remove
        /// </summary>
        [JsonProperty("sceneName")]
        public string? SceneName { get; set; }
        /// <summary>
        /// UUID of the scene to remove
        /// </summary>
        [JsonProperty("sceneUuid")]
        public string? SceneUuid { get; set; }
        /// <summary>
        /// Name of the scene to remove
        /// </summary>
        [JsonProperty("newSceneName")]
        public string NewSceneName { get; set; }
    }

    public record GetSceneSceneTransitionOverride : BaseRequest
    {
        /// <summary>
        /// Name of the scene
        /// </summary>
        [JsonProperty("sceneName")]
        public string? SceneName { get; set; }
        /// <summary>
        /// UUID of the scene
        /// </summary>
        [JsonProperty("sceneUuid")]
        public string? SceneUuid { get; set; }
    }

    public record SetSceneSceneTransitionOverride : BaseRequest
    {
        /// <summary>
        /// Name of the scene
        /// </summary>
        [JsonProperty("sceneName")]
        public string? SceneName { get; set; }
        /// <summary>
        /// UUID of the scene
        /// </summary>
        [JsonProperty("sceneUuid")]
        public string? SceneUuid { get; set; }
        /// <summary>
        /// Name of the scene transition to use as override. Specify null to remove
        /// </summary>
        [JsonProperty("transitionName")]
        public string? TransitionName { get; set; }
        /// <summary>
        /// Duration to use for any overridden transition. Specify null to remove >= 50, &lt;= 20000
        /// </summary>
        [JsonProperty("transitionDuration")]
        public long? TransitionDuration { get; set; }
    }
}
