using Apps.CaptionHub.Webhooks.Models.Payloads.CaptionSet;

namespace Apps.CaptionHub.Webhooks.Models.Responses;

public class RenderingWebhookResponse : CaptionSetWebhookResponse
{
    public RenderingPayload Rendering { get; set; }
}