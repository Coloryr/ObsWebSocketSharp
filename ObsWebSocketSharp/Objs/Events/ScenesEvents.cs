using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ObsWebSocketSharp.Objs.Events;

/// <summary>
/// A new scene has been created.
/// </summary>
public record SceneCreated : BaseEvent
{
    /// <summary>
    /// Name of the new scene
    /// </summary>
    [JsonProperty("sceneName")]
    public string SceneName { get; set; }
    /// <summary>
    /// UUID of the new scene
    /// </summary>
    [JsonProperty("sceneUuid")]
    public string SceneUuid { get; set; }
    /// <summary>
    /// Whether the new scene is a group
    /// </summary>
    [JsonProperty("isGroup")]
    public bool IsGroup { get; set; }
}

/// <summary>
/// A scene has been removed.
/// </summary>
public record SceneRemoved : BaseEvent
{
    /// <summary>
    /// Name of the removed scene
    /// </summary>
    [JsonProperty("sceneName")]
    public string SceneName { get; set; }
    /// <summary>
    /// UUID of the removed scene
    /// </summary>
    [JsonProperty("sceneUuid")]
    public string SceneUuid { get; set; }
    /// <summary>
    /// Whether the scene was a group
    /// </summary>
    [JsonProperty("isGroup")]
    public bool IsGroup { get; set; }
}

/// <summary>
/// The name of a scene has changed.
/// </summary>
public record SceneNameChanged : BaseEvent
{
    /// <summary>
    /// UUID of the scene
    /// </summary>
    [JsonProperty("sceneUuid")]
    public string SceneUuid { get; set; }
    /// <summary>
    /// Old name of the scene
    /// </summary>
    [JsonProperty("oldSceneName")]
    public string OldSceneName { get; set; }
    /// <summary>
    /// New name of the scene
    /// </summary>
    [JsonProperty("sceneName")]
    public string SceneName { get; set; }
}

/// <summary>
/// The current program scene has changed.
/// </summary>
public record CurrentProgramSceneChanged : BaseEvent
{
    /// <summary>
    /// Name of the scene that was switched to
    /// </summary>
    [JsonProperty("sceneName")]
    public string SceneName { get; set; }
    /// <summary>
    /// UUID of the scene that was switched to
    /// </summary>
    [JsonProperty("sceneUuid")]
    public string SceneUuid { get; set; }
}

/// <summary>
/// The current preview scene has changed.
/// </summary>
public record CurrentPreviewSceneChanged : CurrentProgramSceneChanged
{ 
    
}

/// <summary>
/// The list of scenes has changed.
/// 
/// TODO: Make OBS fire this event when scenes are reordered.
/// </summary>
public record SceneListChanged : BaseEvent
{
    /// <summary>
    /// Updated array of scenes
    /// </summary>
    [JsonProperty("scenes")]
    public List<object> Scenes { get; set; }
}