using Apps.CaptionHub.Webhooks.Handlers.WebhookHandlers.Base;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.CaptionHub.Webhooks.Handlers.WebhookHandlers.Project;

public class ProjectVideoReplacedHandler : CaptionHubWebhookHandler
{
    protected override string Event => "project.video_replaced";

    public ProjectVideoReplacedHandler(InvocationContext invocationContext) : base(invocationContext)
    {
    }
}