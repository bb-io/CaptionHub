using Apps.CaptionHub.Webhooks.Handlers.Base;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.CaptionHub.Webhooks.Handlers;

public class ProjectEncodeStateChangedHandler : CaptionHubWebhookHandler
{
    protected override string Event => "projectEncodeState";

    public ProjectEncodeStateChangedHandler(InvocationContext invocationContext) : base(invocationContext)
    {
    }
}