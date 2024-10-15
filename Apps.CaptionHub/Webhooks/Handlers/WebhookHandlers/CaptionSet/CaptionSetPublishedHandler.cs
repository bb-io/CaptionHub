using Apps.CaptionHub.Webhooks.Handlers.WebhookHandlers.Base;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.CaptionHub.Webhooks.Handlers.WebhookHandlers.CaptionSet;

public class CaptionSetPublishedHandler : CaptionHubWebhookHandler
{
    protected override string Event => "caption_set.published";

    public CaptionSetPublishedHandler(InvocationContext invocationContext) : base(invocationContext)
    {
    }
}