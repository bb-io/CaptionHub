using Apps.CaptionHub.Webhooks.Handlers.CallbackHandlers.Base;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.CaptionHub.Webhooks.Handlers.CallbackHandlers;

public class CaptionSetApprovedHandler : CaptionHubBridgeWebhookHandler
{
    protected override string Event => "captionSetApproved";

    public CaptionSetApprovedHandler(InvocationContext invocationContext) : base(invocationContext)
    {
    }
}