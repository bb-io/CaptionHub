using Apps.CaptionHub.Webhooks.Handlers.WebhookHandlers.Base;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.CaptionHub.Webhooks.Handlers.WebhookHandlers.Project;

public class ProjectMetadataUpdatedHandler : CaptionHubWebhookHandler
{
    protected override string Event => "project.metadata_updated";

    public ProjectMetadataUpdatedHandler(InvocationContext invocationContext) : base(invocationContext)
    {
    }
}