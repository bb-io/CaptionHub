using Apps.CaptionHub.Webhooks.Handlers.WebhookHandlers.Base;

namespace Apps.CaptionHub.Webhooks.Handlers.WebhookHandlers.Project;

public class ProjectEncodeFailedHandler : CaptionHubWebhookHandler
{
    protected override string Event => "project.encode_failed";
}