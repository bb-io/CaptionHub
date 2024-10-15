using Apps.CaptionHub.Webhooks.Handlers.WebhookHandlers.Base;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.CaptionHub.Webhooks.Handlers.WebhookHandlers.Project;

public class ProjectUnarchivedHandler : CaptionHubWebhookHandler
{
    protected override string Event => "project.unarchived";

    public ProjectUnarchivedHandler(InvocationContext invocationContext) : base(invocationContext)
    {
    }
}