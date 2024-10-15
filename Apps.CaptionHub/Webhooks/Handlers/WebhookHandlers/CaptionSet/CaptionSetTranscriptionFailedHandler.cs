using Apps.CaptionHub.Webhooks.Handlers.WebhookHandlers.Base;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.CaptionHub.Webhooks.Handlers.WebhookHandlers.CaptionSet;

public class CaptionSetTranscriptionFailedHandler : CaptionHubWebhookHandler
{
    protected override string Event => "caption_set.transcription_failed";

    public CaptionSetTranscriptionFailedHandler(InvocationContext invocationContext) : base(invocationContext)
    {
    }
}