using Blackbird.Applications.Sdk.Common;

namespace Apps.CaptionHub.Webhooks.Models.Payloads.Project;

public class ProjectEncodePayload : ProjectPayload
{
    [Display("Project encoded")]
    public bool ProjectEncoded { get; set; }
}