using Apps.CaptionHub.Webhooks.Handlers.WebhookHandlers.Base;

namespace Apps.CaptionHub.Webhooks.Handlers.WebhookHandlers.Project;

public class ProjectMetadataUpdatedHandler : CaptionHubWebhookHandler
{
    protected override string Event => "project.metadata_updated";
}