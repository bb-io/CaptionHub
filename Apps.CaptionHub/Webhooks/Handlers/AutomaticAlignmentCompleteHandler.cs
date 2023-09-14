using Apps.CaptionHub.Webhooks.Handlers.Base;

namespace Apps.CaptionHub.Webhooks.Handlers;

public class AutomaticAlignmentCompleteHandler : CaptionHubWebhookHandler
{
    protected override string Event => "automaticAlignmentComplete";
}