using Apps.CaptionHub.Webhooks.Handlers.WebhookHandlers.Base;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.CaptionHub.Webhooks.Handlers.WebhookHandlers.CaptionSet;

public class CaptionSetDeletedHandler : CaptionHubWebhookHandler
{
    protected override string Event => "caption_set.deleted";

    public CaptionSetDeletedHandler(InvocationContext invocationContext) : base(invocationContext)
    {
    }
}