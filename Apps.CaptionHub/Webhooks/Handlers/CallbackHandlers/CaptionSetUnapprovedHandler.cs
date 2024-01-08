using Apps.CaptionHub.Webhooks.Handlers.CallbackHandlers.Base;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.CaptionHub.Webhooks.Handlers.CallbackHandlers;

public class CaptionSetUnapprovedHandler : CaptionHubBridgeWebhookHandler
{
    protected override string Event => "captionSetUnapproved";

    public CaptionSetUnapprovedHandler(InvocationContext invocationContext) : base(invocationContext)
    {
    }
}