using Blackbird.Applications.Sdk.Common;

namespace Apps.CaptionHub.Webhooks.Models.Payloads.CaptionSet;

public class RenderingPayload
{
    [Display("Render ID")]
    public string Id { get; set; }
    
    [Display("Render status")]
    public string Stats { get; set; }
    
    [Display("Caption set ID")]
    public string CaptionSetId { get; set; }
    
    [Display("Created at")]
    public DateTime CreatedAt { get; set; }
}