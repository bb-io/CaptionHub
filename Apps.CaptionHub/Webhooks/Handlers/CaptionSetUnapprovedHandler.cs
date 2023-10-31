using Apps.CaptionHub.Webhooks.Handlers.Base;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.CaptionHub.Webhooks.Handlers;

public class CaptionSetUnapprovedHandler : CaptionHubWebhookHandler
{
    protected override string Event => "captionSetUnapproved";

    public CaptionSetUnapprovedHandler(InvocationContext invocationContext) : base(invocationContext)
    {
    }
}