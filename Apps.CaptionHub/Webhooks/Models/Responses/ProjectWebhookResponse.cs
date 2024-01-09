using Apps.CaptionHub.Webhooks.Models.Payloads.Project;

namespace Apps.CaptionHub.Webhooks.Models.Responses;

public class ProjectWebhookResponse
{
    public ProjectPayload Project { get; set; }
}