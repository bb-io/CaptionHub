using Apps.CaptionHub.Webhooks.Handlers.CallbackHandlers.Base;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.CaptionHub.Webhooks.Handlers.CallbackHandlers;

public class AutomaticAlignmentCompleteHandler : CaptionHubBridgeWebhookHandler
{
    protected override string Event => "automaticAlignmentComplete";

    public AutomaticAlignmentCompleteHandler(InvocationContext invocationContext) : base(invocationContext)
    {
    }
}