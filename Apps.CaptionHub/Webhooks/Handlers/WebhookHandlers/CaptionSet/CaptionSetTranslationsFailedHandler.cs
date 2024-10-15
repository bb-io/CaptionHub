using Apps.CaptionHub.Webhooks.Handlers.WebhookHandlers.Base;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.CaptionHub.Webhooks.Handlers.WebhookHandlers.CaptionSet;

public class CaptionSetTranslationsFailedHandler : CaptionHubWebhookHandler
{
    protected override string Event => "caption_set.translations_failed";

    public CaptionSetTranslationsFailedHandler(InvocationContext invocationContext) : base(invocationContext)
    {
    }
}