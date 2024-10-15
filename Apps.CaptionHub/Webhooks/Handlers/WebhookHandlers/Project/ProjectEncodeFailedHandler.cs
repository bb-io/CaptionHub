using Apps.CaptionHub.Webhooks.Handlers.WebhookHandlers.Base;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.CaptionHub.Webhooks.Handlers.WebhookHandlers.Project;

public class ProjectEncodeFailedHandler : CaptionHubWebhookHandler
{
    protected override string Event => "project.encode_failed";

    public ProjectEncodeFailedHandler(InvocationContext invocationContext) : base(invocationContext)
    {
    }
}