using Apps.CaptionHub.Webhooks.Handlers.WebhookHandlers.Base;

namespace Apps.CaptionHub.Webhooks.Handlers.WebhookHandlers.CaptionSet;

public class CaptionSetTranslationsFailedHandler : CaptionHubWebhookHandler
{
    protected override string Event => "caption_set.translations_failed";
}