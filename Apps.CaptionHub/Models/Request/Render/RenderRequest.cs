using Apps.CaptionHub.Models.Request.CaptionSet;
using Blackbird.Applications.Sdk.Common;

namespace Apps.CaptionHub.Models.Request.Render;

public class RenderRequest : CaptionSetRequest
{
    [Display("Render ID")]
    public string RenderId { get; set; }
}