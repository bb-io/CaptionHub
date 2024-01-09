using Apps.CaptionHub.Webhooks.Handlers.WebhookHandlers.Base;

namespace Apps.CaptionHub.Webhooks.Handlers.WebhookHandlers.CaptionSet;

public class CaptionSetRenderedHandler : CaptionHubWebhookHandler
{
    protected override string Event => "caption_set.rendered";
}