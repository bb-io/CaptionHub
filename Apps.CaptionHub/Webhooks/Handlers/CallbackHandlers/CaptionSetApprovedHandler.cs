using Apps.CaptionHub.Webhooks.Bridge.Base;
using Apps.CaptionHub.Webhooks.Handlers.CallbackHandlers.Base;
using Apps.CaptionHub.Webhooks.Handlers.WebhookHandlers.Base;
using Apps.CaptionHub.Webhooks.Models.Inputs;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.CaptionHub.Webhooks.Handlers.CallbackHandlers;

public class CaptionSetApprovedHandler : BaseWebhookBridgeHandler
{
    public static string Event => "caption_set.workflow.approved";

    public CaptionSetApprovedHandler(InvocationContext invocationContext, [WebhookParameter] CaptionSetApprovedWebhookInput input) : base(invocationContext,Event, input.ProjectId)
    {
    }
}