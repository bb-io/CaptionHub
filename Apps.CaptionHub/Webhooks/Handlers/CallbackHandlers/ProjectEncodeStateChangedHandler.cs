using Apps.CaptionHub.Webhooks.Handlers.CallbackHandlers.Base;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.CaptionHub.Webhooks.Handlers.CallbackHandlers;

public class ProjectEncodeStateChangedHandler : CaptionHubBridgeWebhookHandler
{
    protected override string Event => "projectEncodeState";

    public ProjectEncodeStateChangedHandler(InvocationContext invocationContext) : base(invocationContext)
    {
    }
}