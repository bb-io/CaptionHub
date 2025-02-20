using Apps.CaptionHub.Webhooks.Handlers.CallbackHandlers.Base;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.CaptionHub.Webhooks.Handlers.CallbackHandlers;

public class CaptionSetUnapprovedHandler : CaptionHubBridgeWebhookHandler
{
    protected override string Event => "caption_set.workflow.unapproved";

    public CaptionSetUnapprovedHandler(InvocationContext invocationContext) : base(invocationContext)
    {
    }
}