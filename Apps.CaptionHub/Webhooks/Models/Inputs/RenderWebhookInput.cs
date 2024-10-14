using Blackbird.Applications.Sdk.Common;

namespace Apps.CaptionHub.Webhooks.Models.Inputs;

public class RenderWebhookInput : CaptionSetWebhookInput
{
    [Display("Render ID")]
    public string? RenderId { get; set; }
}