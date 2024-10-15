using Apps.CaptionHub.Webhooks.Handlers.WebhookHandlers.Base;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.CaptionHub.Webhooks.Handlers.WebhookHandlers.CaptionSet;

public class CaptionSetTranscribedHandler : CaptionHubWebhookHandler
{
    protected override string Event => "caption_set.transcribed";

    public CaptionSetTranscribedHandler(InvocationContext invocationContext) : base(invocationContext)
    {
    }
}