using Apps.CaptionHub.Webhooks.Handlers.WebhookHandlers.Base;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.CaptionHub.Webhooks.Handlers.WebhookHandlers.Project;

public class ProjectCreatedHandler : CaptionHubWebhookHandler
{
    protected override string Event => "project.created";

    public ProjectCreatedHandler(InvocationContext invocationContext) : base(invocationContext)
    {
    }
}