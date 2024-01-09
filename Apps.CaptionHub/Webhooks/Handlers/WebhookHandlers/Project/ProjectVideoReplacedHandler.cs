using Apps.CaptionHub.Webhooks.Handlers.WebhookHandlers.Base;

namespace Apps.CaptionHub.Webhooks.Handlers.WebhookHandlers.Project;

public class ProjectVideoReplacedHandler : CaptionHubWebhookHandler
{
    protected override string Event => "project.video_replaced";
}