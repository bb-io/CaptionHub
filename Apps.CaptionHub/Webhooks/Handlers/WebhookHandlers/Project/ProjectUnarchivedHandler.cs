using Apps.CaptionHub.Webhooks.Handlers.WebhookHandlers.Base;

namespace Apps.CaptionHub.Webhooks.Handlers.WebhookHandlers.Project;

public class ProjectUnarchivedHandler : CaptionHubWebhookHandler
{
    protected override string Event => "project.unarchived";
}