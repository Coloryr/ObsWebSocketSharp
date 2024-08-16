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
    /// Gets the active and show state of a source.
    /// </summary>
    public record GetSourceActive : BaseResponse
    {
        /// <summary>
        /// Whether the source is showing in Program
        /// </summary>
        [JsonProperty("videoActive")]
        public bool VideoActive { get; set; }
        /// <summary>
        /// Whether the source is showing in the UI (Preview, Projector, Properties)
        /// </summary>
        [JsonProperty("videoShowing")]
        public bool VideoShowing { get; set; }
    }

    /// <summary>
    /// Gets a Base64-encoded screenshot of a source.
    /// </summary>
    public record GetSourceScreenshot : BaseResponse
    {
        /// <summary>
        /// Base64-encoded screenshot
        /// </summary>
        [JsonProperty("imageData")]
        public string ImageData { get; set; }
    }

    /// <summary>
    /// Saves a screenshot of a source to the filesystem.
    /// </summary>
    public record SaveSourceScreenshot : BaseResponse
    {
        
    }
}
