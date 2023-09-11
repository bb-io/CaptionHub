using Blackbird.Applications.Sdk.Common;

namespace Apps.CaptionHub.Models.Entities;

public class RenderingEntity
{
    [Display("Rendering ID")]
    public string Id { get; set; }

    [Display("Status")]
    public string Status { get; set; }

    [Display("Caption set ID")]
    public string CaptionSetId { get; set; }

    [Display("Created at")]
    public DateTime CreatedAt { get; set; }
}