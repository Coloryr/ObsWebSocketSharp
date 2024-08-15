using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ObsWebSocketSharp.Objs.Events;

public abstract record BaseSceneItem : BaseEvent
{
    /// <summary>
    /// Name of the scene the item is in
    /// </summary>
    [JsonProperty("sceneName")]
    public string SceneName { get; set; }
    /// <summary>
    /// UUID of the scene the item is in
    /// </summary>
    [JsonProperty("sceneUuid")]
    public string SceneUuid { get; set; }
    /// <summary>
    /// Numeric ID of the scene item
    /// </summary>
    [JsonProperty("sceneItemId")]
    public long SceneItemId { get; set; }
}

/// <summary>
/// A scene item has been created.
/// </summary>
public record SceneItemCreated : BaseEvent
{
    /// <summary>
    /// Name of the scene the item was added to
    /// </summary>
    [JsonProperty("sceneName")]
    public string SceneName { get; set; }
    /// <summary>
    /// UUID of the scene the item was added to
    /// </summary>
    [JsonProperty("sceneUuid")]
    public string SceneUuid { get; set; }
    /// <summary>
    /// Name of the underlying source (input/scene)
    /// </summary>
    [JsonProperty("sourceName")]
    public string SourceName { get; set; }
    /// <summary>
    /// UUID of the underlying source (input/scene)
    /// </summary>
    [JsonProperty("sourceUuid")]
    public string SourceUuid { get; set; }
    /// <summary>
    /// Numeric ID of the scene item
    /// </summary>
    [JsonProperty("sceneItemId")]
    public long SceneItemId { get; set; }
    /// <summary>
    /// Index position of the item
    /// </summary>
    [JsonProperty("sceneItemIndex")]
    public int SceneItemIndex { get; set; }
}

/// <summary>
/// A scene item has been removed.
/// 
/// This event is not emitted when the scene the item is in is removed.
/// </summary>
public record SceneItemRemoved : BaseEvent
{
    /// <summary>
    /// Name of the scene the item was removed from
    /// </summary>
    [JsonProperty("sceneName")]
    public string SceneName { get; set; }
    /// <summary>
    /// UUID of the scene the item was removed from
    /// </summary>
    [JsonProperty("sceneUuid")]
    public string SceneUuid { get; set; }
    /// <summary>
    /// Name of the underlying source (input/scene)
    /// </summary>
    [JsonProperty("sourceName")]
    public string SourceName { get; set; }
    /// <summary>
    /// UUID of the underlying source (input/scene)
    /// </summary>
    [JsonProperty("sourceUuid")]
    public string SourceUuid { get; set; }
    /// <summary>
    /// Numeric ID of the scene item
    /// </summary>
    [JsonProperty("sceneItemId")]
    public long SceneItemId { get; set; }
}

/// <summary>
/// A scene's item list has been reindexed.
/// </summary>
public record SceneItemListReindexed : BaseEvent
{
    /// <summary>
    /// Name of the scene
    /// </summary>
    [JsonProperty("sceneName")]
    public string SceneName { get; set; }
    /// <summary>
    /// UUID of the scene
    /// </summary>
    [JsonProperty("sceneUuid")]
    public string SceneUuid { get; set; }
    /// <summary>
    /// Array of scene item objects
    /// </summary>
    [JsonProperty("sceneItems")]
    public List<object> SceneItems { get; set; }
}

/// <summary>
/// A scene item's enable state has changed.
/// </summary>
public record SceneItemEnableStateChanged : BaseSceneItem
{
    /// <summary>
    /// Whether the scene item is enabled (visible)
    /// </summary>
    [JsonProperty("sceneItemEnabled")]
    public bool SceneItemEnabled { get; set; }
}

/// <summary>
/// A scene item's lock state has changed.
/// </summary>
public record SceneItemLockStateChanged : BaseSceneItem
{
    /// <summary>
    /// Whether the scene item is locked
    /// </summary>
    [JsonProperty("sceneItemLocked")]
    public bool SceneItemLocked { get; set; }
}

/// <summary>
/// A scene item has been selected in the Ui.
/// </summary>
public record SceneItemSelected : BaseSceneItem
{
    
}

/// <summary>
/// A scene item has been selected in the Ui.
/// </summary>
public record SceneItemTransformChanged : BaseSceneItem
{
    /// <summary>
    /// New transform/crop info of the scene item
    /// </summary>
    [JsonProperty("sceneItemTransform")]
    public object SceneItemTransform { get; set; }
}