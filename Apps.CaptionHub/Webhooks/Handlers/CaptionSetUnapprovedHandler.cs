using Apps.CaptionHub.Webhooks.Handlers.Base;

namespace Apps.CaptionHub.Webhooks.Handlers;

public class CaptionSetUnapprovedHandler : CaptionHubWebhookHandler
{
    protected override string Event => "captionSetUnapproved";
}