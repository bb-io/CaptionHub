using Apps.CaptionHub.Webhooks.Handlers.Base;

namespace Apps.CaptionHub.Webhooks.Handlers;

public class AutomaticTranscriptionCompleteHandler : CaptionHubWebhookHandler
{
    protected override string Event => "automaticTranscriptionComplete";
}