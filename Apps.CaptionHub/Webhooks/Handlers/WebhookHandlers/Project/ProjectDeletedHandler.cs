using Apps.CaptionHub.Webhooks.Handlers.WebhookHandlers.Base;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.CaptionHub.Webhooks.Handlers.WebhookHandlers.Project;

public class ProjectDeletedHandler : CaptionHubWebhookHandler
{
    protected override string Event => "project.deleted";

    public ProjectDeletedHandler(InvocationContext invocationContext) : base(invocationContext)
    {
    }
}