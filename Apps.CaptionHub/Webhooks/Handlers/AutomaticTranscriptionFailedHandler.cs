using Apps.CaptionHub.Webhooks.Handlers.Base;

namespace Apps.CaptionHub.Webhooks.Handlers;

public class AutomaticTranscriptionFailedHandler : CaptionHubWebhookHandler
{
    protected override string Event => "automaticTranscriptionFailed";
}