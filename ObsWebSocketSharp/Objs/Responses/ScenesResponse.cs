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
    /// Gets an array of all scenes in OBS.
    /// </summary>
    public record GetSceneList : BaseResponse
    {
        /// <summary>
        /// Current program scene name. Can be `null` if internal state desync
        /// </summary>
        [JsonProperty("currentProgramSceneName")]
        public string CurrentProgramSceneName { get; set; }
        /// <summary>
        /// Current program scene UUID. Can be `null` if internal state desync
        /// </summary>
        [JsonProperty("currentProgramSceneUuid")]
        public string CurrentProgramSceneUuid { get; set; }
        /// <summary>
        /// Current preview scene name. `null` if not in studio mode
        /// </summary>
        [JsonProperty("currentPreviewSceneName")]
        public string CurrentPreviewSceneName { get; set; }
        /// <summary>
        /// Current preview scene UUID. `null` if not in studio mode
        /// </summary>
        [JsonProperty("currentPreviewSceneUuid")]
        public string CurrentPreviewSceneUuid { get; set; }
        /// <summary>
        /// Array of scenes
        /// </summary>
        [JsonProperty("scenes")]
        public List<object> Scenes { get; set; }
    }

    /// <summary>
    /// Gets an array of all groups in OBS.
    /// </summary>
    public record GetGroupList : BaseResponse
    {
        /// <summary>
        /// Array of group names
        /// </summary>
        [JsonProperty("groups")]
        public List<string> Groups { get; set; }
    }

    /// <summary>
    /// Gets the current program scene.
    /// </summary>
    public record GetCurrentProgramScene : BaseResponse
    {
        /// <summary>
        /// Current program scene name
        /// </summary>
        [JsonProperty("sceneName")]
        public string SceneName { get; set; }
        /// <summary>
        /// Current program scene UUID
        /// </summary>
        [JsonProperty("sceneUuid")]
        public string SceneUuid { get; set; }
        /// <summary>
        /// Current program scene name (Deprecated)
        /// </summary>
        [JsonProperty("currentProgramSceneName")]
        public string CurrentProgramSceneName { get; set; }
        /// <summary>
        /// Current program scene UUID (Deprecated)
        /// </summary>
        [JsonProperty("currentProgramSceneUuid")]
        public string CurrentProgramSceneUuid { get; set; }
    }

    /// <summary>
    /// Sets the current program scene.
    /// </summary>
    public record SetCurrentProgramScene : BaseResponse
    { 
    
    }

    /// <summary>
    /// Gets the current preview scene.
    /// </summary>
    public record GetCurrentPreviewScene : BaseResponse
    {
        /// <summary>
        /// Current program scene name
        /// </summary>
        [JsonProperty("sceneName")]
        public string SceneName { get; set; }
        /// <summary>
        /// Current program scene UUID
        /// </summary>
        [JsonProperty("sceneUuid")]
        public string SceneUuid { get; set; }
        /// <summary>
        /// Current program scene name
        /// </summary>
        [JsonProperty("currentProgramSceneName")]
        public string CurrentProgramSceneName { get; set; }
        /// <summary>
        /// Current program scene UUID
        /// </summary>
        [JsonProperty("currentProgramSceneUuid")]
        public string CurrentProgramSceneUuid { get; set; }
    }

    /// <summary>
    /// Sets the current preview scene.
    /// </summary>
    public record SetCurrentPreviewScene : BaseResponse
    { 
    
    }

    /// <summary>
    /// Creates a new scene in OBS.
    /// </summary>
    public record CreateScene : BaseResponse
    {
        /// <summary>
        /// UUID of the created scene
        /// </summary>
        [JsonProperty("sceneUuid")]
        public string SceneUuid { get; set; }
    }

    /// <summary>
    /// Removes a scene from OBS.
    /// </summary>
    public record RemoveScene : BaseResponse
    {
        
    }

    /// <summary>
    /// Sets the name of a scene (rename).
    /// </summary>
    public record SetSceneName : BaseResponse
    { 
        
    }

    /// <summary>
    /// Gets the scene transition overridden for a scene.
    /// </summary>
    public record GetSceneSceneTransitionOverride : BaseResponse
    {
        /// <summary>
        /// Name of the overridden scene transition, else null
        /// </summary>
        [JsonProperty("transitionName")]
        public string? TransitionName { get; set; }
        /// <summary>
        /// Duration of the overridden scene transition, else null
        /// </summary>
        [JsonProperty("transitionDuration")]
        public long? TransitionDuration { get; set; }
    }

    /// <summary>
    /// Sets the scene transition overridden for a scene.
    /// </summary>
    public record SetSceneSceneTransitionOverride : BaseResponse
    { 
    
    }   
}
