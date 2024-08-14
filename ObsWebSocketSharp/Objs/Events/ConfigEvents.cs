using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ObsWebSocketSharp.Objs.Events;

/// <summary>
/// The current scene collection has begun changing.
/// 
/// Note: We recommend using this event to trigger a pause of all polling requests, as performing any requests during a scene collection change is considered undefined behavior and can cause crashes!
/// </summary>
public record CurrentSceneCollectionChanging : BaseEvent
{
    /// <summary>
    /// Name of the current scene collection
    /// </summary>
    [JsonProperty("sceneCollectionName")]
    public string SceneCollectionName { get; set; }
}

/// <summary>
/// The current scene collection has changed.
/// 
/// Note: If polling has been paused during <see cref="CurrentSceneCollectionChanging" />, this is the que to restart polling.
/// </summary>
public record CurrentSceneCollectionChanged : CurrentSceneCollectionChanging
{ 
    
}

/// <summary>
/// The scene collection list has changed.
/// </summary>
public record SceneCollectionListChanged : BaseEvent
{
    /// <summary>
    /// Updated list of scene collections
    /// </summary>
    [JsonProperty("sceneCollections")]
    public string SceneCollections { get; set; }
}

/// <summary>
/// The current profile has begun changing.
/// </summary>
public record CurrentProfileChanging : BaseEvent
{
    /// <summary>
    /// Name of the current profile
    /// </summary>
    [JsonProperty("profileName")]
    public string ProfileName { get; set; }
}

/// <summary>
/// The current profile has changed.
/// </summary>
public record CurrentProfileChanged : BaseEvent
{
    /// <summary>
    /// Name of the new profile
    /// </summary>
    [JsonProperty("profileName")]
    public string ProfileName { get; set; }
}

/// <summary>
/// The profile list has changed.
/// </summary>
public record ProfileListChanged : BaseEvent
{
    /// <summary>
    /// Updated list of profiles
    /// </summary>
    [JsonProperty("profiles")]
    public List<string> Profiles { get; set; }
}