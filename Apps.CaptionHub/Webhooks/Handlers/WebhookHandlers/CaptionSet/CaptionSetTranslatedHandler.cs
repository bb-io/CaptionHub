using Apps.CaptionHub.Webhooks.Handlers.WebhookHandlers.Base;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.CaptionHub.Webhooks.Handlers.WebhookHandlers.CaptionSet;

public class CaptionSetTranslatedHandler : CaptionHubWebhookHandler
{
    protected override string Event => "caption_set.translated";

    public CaptionSetTranslatedHandler(InvocationContext invocationContext) : base(invocationContext)
    {
    }
}