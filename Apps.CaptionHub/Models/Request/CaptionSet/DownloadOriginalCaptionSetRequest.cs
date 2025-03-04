using Apps.CaptionHub.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Newtonsoft.Json;

namespace Apps.CaptionHub.Models.Request.CaptionSet;

public class DownloadOriginalCaptionSetRequest
{
    [Display("Project ID")]
    [JsonProperty("project_id")]
    [DataSource(typeof(ProjectDataHandler))]
    public string ProjectId { get; set; }
    
    [Display("Captions format")]
    [JsonProperty("captions_format")]
    [DataSource(typeof(CaptionsFormatDataHandler))]
    public string CaptionsFormat { get; set; }
}