using Apps.CaptionHub.Webhooks.Handlers.WebhookHandlers.Base;

namespace Apps.CaptionHub.Webhooks.Handlers.WebhookHandlers.CaptionSet;

public class CaptionSetDeletedHandler : CaptionHubWebhookHandler
{
    protected override string Event => "caption_set.deleted";
}