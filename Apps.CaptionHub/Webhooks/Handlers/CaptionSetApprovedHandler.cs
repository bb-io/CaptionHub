using Apps.CaptionHub.Webhooks.Handlers.Base;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.CaptionHub.Webhooks.Handlers;

public class CaptionSetApprovedHandler : CaptionHubWebhookHandler
{
    protected override string Event => "captionSetApproved";

    public CaptionSetApprovedHandler(InvocationContext invocationContext) : base(invocationContext)
    {
    }
}