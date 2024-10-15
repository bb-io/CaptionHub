using Apps.CaptionHub.Webhooks.Handlers.WebhookHandlers.Base;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.CaptionHub.Webhooks.Handlers.WebhookHandlers.CaptionSet;

public class CaptionSetUpdatedHandler : CaptionHubWebhookHandler
{
    protected override string Event => "caption_set.updated";

    public CaptionSetUpdatedHandler(InvocationContext invocationContext) : base(invocationContext)
    {
    }
}