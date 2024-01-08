using Apps.CaptionHub.Webhooks.Handlers.CallbackHandlers.Base;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.CaptionHub.Webhooks.Handlers.CallbackHandlers;

public class AutomaticTranscriptionCompleteHandler : CaptionHubBridgeWebhookHandler
{
    protected override string Event => "automaticTranscriptionComplete";

    public AutomaticTranscriptionCompleteHandler(InvocationContext invocationContext) : base(invocationContext)
    {
    }
}