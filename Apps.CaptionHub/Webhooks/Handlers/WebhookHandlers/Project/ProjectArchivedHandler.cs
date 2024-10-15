using Apps.CaptionHub.Webhooks.Handlers.WebhookHandlers.Base;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.CaptionHub.Webhooks.Handlers.WebhookHandlers.Project;

public class ProjectArchivedHandler : CaptionHubWebhookHandler
{
    protected override string Event => "project.archived";

    public ProjectArchivedHandler(InvocationContext invocationContext) : base(invocationContext)
    {
    }
}