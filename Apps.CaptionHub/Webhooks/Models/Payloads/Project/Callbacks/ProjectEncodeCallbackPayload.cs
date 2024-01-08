using Blackbird.Applications.Sdk.Common;

namespace Apps.CaptionHub.Webhooks.Models.Payloads.Project.Callbacks;

public class ProjectEncodeCallbackPayload : ProjectCallbackPayload
{
    [Display("Project encoded")]
    public bool ProjectEncoded { get; set; }
}