using Apps.CaptionHub.Webhooks.Handlers.WebhookHandlers.Base;

namespace Apps.CaptionHub.Webhooks.Handlers.WebhookHandlers.CaptionSet;

public class CaptionSetUpdatedHandler : CaptionHubWebhookHandler
{
    protected override string Event => "caption_set.updated";
}