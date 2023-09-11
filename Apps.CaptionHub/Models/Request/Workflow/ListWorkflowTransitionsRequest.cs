using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.CaptionHub.Models.Request.Workflow;

public class ListWorkflowTransitionsRequest
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
    public string? ProjectId { get; set; }
}