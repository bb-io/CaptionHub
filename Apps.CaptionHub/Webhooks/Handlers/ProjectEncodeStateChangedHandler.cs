using Apps.CaptionHub.Webhooks.Handlers.Base;

namespace Apps.CaptionHub.Webhooks.Handlers;

public class ProjectEncodeStateChangedHandler : CaptionHubWebhookHandler
{
    protected override string Event => "projectEncodeState";
}