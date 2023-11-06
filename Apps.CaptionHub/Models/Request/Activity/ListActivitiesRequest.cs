using Apps.CaptionHub.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Newtonsoft.Json;

namespace Apps.CaptionHub.Models.Request.Activity;

public class ListActivitiesRequest
{
    [JsonProperty("caption_set_id")]
    [Display("Caption set ID")]
    public string? CaptionSetId { get; set; }

    [JsonProperty("end_date")]
    [Display("End date")]
    public string? EndDate { get; set; }

    [JsonProperty("from_date")] 
    [Display("From date")]
    public string? FromDate { get; set; }

    [JsonProperty("project_id")] 
    [Display("Project ID")]
    [DataSource(typeof(ProjectDataHandler))]
    public string? ProjectId { get; set; }
}