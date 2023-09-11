using Apps.CaptionHub.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Newtonsoft.Json;

namespace Apps.CaptionHub.Models.Request.CaptionSet;

public class DownloadTranslatedCaptionSetRequest
{
    [Display("Captions format")]
    [JsonProperty("captions_format")]
    [DataSource(typeof(CaptionsFormatDataHandler))]
    public string CaptionsFormat { get; set; }
    
    [Display("Caption set ID")]
    [JsonProperty("caption_set_id")]
    public string CaptionSetId { get; set; }
}