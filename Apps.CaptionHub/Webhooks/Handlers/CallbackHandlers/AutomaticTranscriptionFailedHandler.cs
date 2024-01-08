using Apps.CaptionHub.Webhooks.Handlers.CallbackHandlers.Base;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.CaptionHub.Webhooks.Handlers.CallbackHandlers;

public class AutomaticTranscriptionFailedHandler : CaptionHubBridgeWebhookHandler
{
    protected override string Event => "automaticTranscriptionFailed";

    public AutomaticTranscriptionFailedHandler(InvocationContext invocationContext) : base(invocationContext)
    {
    }
}