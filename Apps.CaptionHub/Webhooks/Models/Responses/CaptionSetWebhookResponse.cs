using Apps.CaptionHub.Webhooks.Models.Payloads.CaptionSet;

namespace Apps.CaptionHub.Webhooks.Models.Responses;

public class CaptionSetWebhookResponse : ProjectWebhookResponse
{
    public CaptionSetPayload CaptionSet { get; set; }
}