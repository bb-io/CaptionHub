using Apps.CaptionHub.Webhooks.Handlers.CallbackHandlers.Base;
using Apps.CaptionHub.Webhooks.Handlers.WebhookHandlers.Base;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.CaptionHub.Webhooks.Handlers.CallbackHandlers;

public class CaptionSetApprovedHandler : CaptionHubWebhookHandler
{
    protected override string Event => "caption_set.workflow.approved";

    public CaptionSetApprovedHandler(InvocationContext invocationContext) : base(invocationContext)
    {
    }
}