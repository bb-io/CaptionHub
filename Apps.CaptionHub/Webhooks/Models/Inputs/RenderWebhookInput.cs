using Apps.CaptionHub.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.CaptionHub.Webhooks.Models.Inputs;

public class RenderWebhookInput : CaptionSetWebhookInput
{
    [Display("Render ID")]
    public string? RenderId { get; set; }

}