using Apps.CaptionHub.Webhooks.Handlers.WebhookHandlers.Base;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.CaptionHub.Webhooks.Handlers.WebhookHandlers.CaptionSet;

public class CaptionSetCreatedHandler : CaptionHubWebhookHandler
{
    protected override string Event => "caption_set.created";

    public CaptionSetCreatedHandler(InvocationContext invocationContext) : base(invocationContext)
    {
    }
}