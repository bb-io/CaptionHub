using Blackbird.Applications.Sdk.Common;

namespace Apps.CaptionHub.Webhooks.Models.Payloads.Project.Callbacks;

public class ProjectCallbackPayload
{
    [Display("Project ID")]
    public string ProjectId { get; set; }
}