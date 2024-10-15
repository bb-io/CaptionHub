using Blackbird.Applications.Sdk.Common;

namespace Apps.CaptionHub.Webhooks.Models.Inputs;

public class CaptionSetWebhookInput : ProjectWebhookInput
{
    [Display("Caption set ID")]
    public string? CaptionSetId { get; set; }
}