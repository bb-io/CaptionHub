using Blackbird.Applications.Sdk.Common;

namespace Apps.CaptionHub.Webhooks.Models.Payloads.Project;

public class ProjectPayload
{
    [Display("Project ID")]
    public string ProjectId { get; set; }
}