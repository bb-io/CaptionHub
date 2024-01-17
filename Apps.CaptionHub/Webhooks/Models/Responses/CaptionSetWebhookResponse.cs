using Apps.CaptionHub.Webhooks.Models.Payloads.CaptionSet;
using Blackbird.Applications.Sdk.Common;

namespace Apps.CaptionHub.Webhooks.Models.Responses;

public class CaptionSetWebhookResponse : ProjectWebhookResponse
{
    [Display("Caption set")]
    public CaptionSetPayload CaptionSet { get; set; }
}