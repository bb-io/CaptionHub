using Apps.CaptionHub.Webhooks.Handlers.Base;

namespace Apps.CaptionHub.Webhooks.Handlers;

public class CaptionSetApprovedHandler : CaptionHubWebhookHandler
{
    protected override string Event => "captionSetApproved";
}