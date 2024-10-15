using Apps.CaptionHub.Webhooks.Handlers.WebhookHandlers.Base;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.CaptionHub.Webhooks.Handlers.WebhookHandlers.CaptionSet;

public class CaptionSetPublishFailedHandler : CaptionHubWebhookHandler
{
    protected override string Event => "caption_set.publish_failed";

    public CaptionSetPublishFailedHandler(InvocationContext invocationContext) : base(invocationContext)
    {
    }
}