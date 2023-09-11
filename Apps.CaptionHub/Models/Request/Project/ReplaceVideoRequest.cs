using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.CaptionHub.Models.Request.Project;

public class ReplaceVideoRequest
{
    [Display("Original media URL")]
    [JsonProperty("original_media_url")]
    public string OriginalMediaUrl { get; set; }
}