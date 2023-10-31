using Apps.CaptionHub.Webhooks.Handlers.Base;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.CaptionHub.Webhooks.Handlers;

public class AutomaticAlignmentCompleteHandler : CaptionHubWebhookHandler
{
    protected override string Event => "automaticAlignmentComplete";

    public AutomaticAlignmentCompleteHandler(InvocationContext invocationContext) : base(invocationContext)
    {
    }
}