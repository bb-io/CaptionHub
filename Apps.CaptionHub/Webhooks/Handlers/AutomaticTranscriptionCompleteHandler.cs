using Apps.CaptionHub.Webhooks.Handlers.Base;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.CaptionHub.Webhooks.Handlers;

public class AutomaticTranscriptionCompleteHandler : CaptionHubWebhookHandler
{
    protected override string Event => "automaticTranscriptionComplete";

    public AutomaticTranscriptionCompleteHandler(InvocationContext invocationContext) : base(invocationContext)
    {
    }
}