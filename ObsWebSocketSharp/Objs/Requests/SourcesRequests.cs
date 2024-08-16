using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ObsWebSocketSharp.Objs.Requests;

public static partial class Request
{
    public record GetSourceActive : BaseRequest
    {
        /// <summary>
        /// Name of the source to get the active state of
        /// </summary>
        [JsonProperty("sourceName")]
        public string? SourceName { get; set; }
        /// <summary>
        /// UUID of the source to get the active state of
        /// </summary>
        [JsonProperty("sourceUuid")]
        public string? SourceUuid { get; set; }
    }

    public record GetSourceScreenshot : BaseRequest
    {
        /// <summary>
        /// Name of the source to take a screenshot of
        /// </summary>
        [JsonProperty("sourceName")]
        public string? SourceName { get; set; }
        /// <summary>
        /// UUID of the source to take a screenshot of
        /// </summary>
        [JsonProperty("sourceUuid")]
        public string? SourceUuid { get; set; }
        /// <summary>
        /// Image compression format to use. Use <see cref="GetVersion"/> to get compatible image formats
        /// </summary>
        [JsonProperty("imageFormat")]
        public string ImageFormat { get; set; }
        /// <summary>
        /// Width to scale the screenshot to >= 8, &lt;= 4096
        /// </summary>
        [JsonProperty("imageWidth")]
        public uint? ImageWidth { get; set; }
        /// <summary>
        /// Height to scale the screenshot to >= 8, &lt;= 4096
        /// </summary>
        [JsonProperty("imageHeight")]
        public uint? ImageHeight { get; set; }
        /// <summary>
        /// Compression quality to use. 0 for high compression, 100 for uncompressed. -1 to use "default" (whatever that means, idk) >= -1, &lt;= 100
        /// </summary>
        [JsonProperty("imageCompressionQuality")]
        public int? ImageCompressionQuality { get; set; } = -1;
    }

    public record SaveSourceScreenshot : BaseRequest
    {
        /// <summary>
        /// Name of the source to take a screenshot of
        /// </summary>
        [JsonProperty("sourceName")]
        public string? SourceName { get; set; }
        /// <summary>
        /// UUID of the source to take a screenshot of
        /// </summary>
        [JsonProperty("sourceUuid")]
        public string? SourceUuid { get; set; }
        /// <summary>
        /// Image compression format to use. Use <see cref="GetVersion"/> to get compatible image formats
        /// </summary>
        [JsonProperty("imageFormat")]
        public string ImageFormat { get; set; }
        /// <summary>
        /// Path to save the screenshot file to. Eg. C:\Users\user\Desktop\screenshot.png
        /// </summary>
        [JsonProperty("imageFilePath")]
        public string ImageFilePath { get; set; }
        /// <summary>
        /// Width to scale the screenshot to >= 8, &lt;= 4096
        /// </summary>
        [JsonProperty("imageWidth")]
        public uint? ImageWidth { get; set; }
        /// <summary>
        /// Height to scale the screenshot to >= 8, &lt;= 4096
        /// </summary>
        [JsonProperty("imageHeight")]
        public uint? ImageHeight { get; set; }
        /// <summary>
        /// Compression quality to use. 0 for high compression, 100 for uncompressed. -1 to use "default" (whatever that means, idk) >= -1, &lt;= 100
        /// </summary>
        [JsonProperty("imageCompressionQuality")]
        public int? ImageCompressionQuality { get; set; } = -1;
    }
}
