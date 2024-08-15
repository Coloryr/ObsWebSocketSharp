using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ObsWebSocketSharp.Objs.Events;

public abstract record BaseSourceFilter : BaseEvent
{
    /// <summary>
    /// Name of the source the filter is on
    /// </summary>
    [JsonProperty("sourceName")]
    public string SourceName { get; set; }
    /// <summary>
    /// New name of the filter
    /// </summary>
    [JsonProperty("filterName")]
    public string FilterName { get; set; }
}

/// <summary>
/// A source's filter list has been reindexed.
/// </summary>
public record SourceFilterListReindexed : BaseEvent
{
    /// <summary>
    /// Name of the source
    /// </summary>
    [JsonProperty("sourceName")]
    public string SourceName { get; set; }
    /// <summary>
    /// Array of filter objects
    /// </summary>
    [JsonProperty("filters")]
    public List<object> Filters { get; set; }
}

/// <summary>
/// A filter has been added to a source.
/// </summary>
public record SourceFilterCreated : BaseEvent
{
    /// <summary>
    /// Name of the source the filter was added to
    /// </summary>
    [JsonProperty("sourceName")]
    public string SourceName { get; set; }
    /// <summary>
    /// Name of the filter
    /// </summary>
    [JsonProperty("filterName")]
    public string FilterName { get; set; }
    /// <summary>
    /// The kind of the filter
    /// </summary>
    [JsonProperty("filterKind")]
    public string FilterKind { get; set; }
    /// <summary>
    /// Index position of the filter
    /// </summary>
    [JsonProperty("filterIndex")]
    public long FilterIndex { get; set; }
    /// <summary>
    /// The settings configured to the filter when it was created
    /// </summary>
    [JsonProperty("filterSettings")]
    public object FilterSettings { get; set; }
    /// <summary>
    /// The default settings for the filter
    /// </summary>
    [JsonProperty("defaultFilterSettings")]
    public object DefaultFilterSettings { get; set; }
}

/// <summary>
/// A filter has been removed from a source.
/// </summary>
public record SourceFilterRemoved : BaseSourceFilter
{
    
}

/// <summary>
/// The name of a source filter has changed.
/// </summary>
public record SourceFilterNameChanged : BaseEvent
{
    /// <summary>
    /// The source the filter is on
    /// </summary>
    [JsonProperty("sourceName")]
    public string SourceName { get; set; }
    /// <summary>
    /// Old name of the filter
    /// </summary>
    [JsonProperty("oldFilterName")]
    public string OldFilterName { get; set; }
    /// <summary>
    /// New name of the filter
    /// </summary>
    [JsonProperty("filterName")]
    public string FilterName { get; set; }
}

/// <summary>
/// An source filter's settings have changed (been updated).
/// </summary>
public record SourceFilterSettingsChanged : BaseSourceFilter
{
    /// <summary>
    /// New settings object of the filter
    /// </summary>
    [JsonProperty("filterSettings")]
    public object FilterSettings { get; set; }
}

/// <summary>
/// A source filter's enable state has changed.
/// </summary>
public record SourceFilterEnableStateChanged : BaseSourceFilter
{
    /// <summary>
    /// Whether the filter is enabled
    /// </summary>
    [JsonProperty("filterEnabled")]
    public bool FilterEnabled { get; set; }
}