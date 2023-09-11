using Blackbird.Applications.Sdk.Common;

namespace Apps.CaptionHub.Models.Request.CaptionSet;

public class CaptionSetRequest
{
    [Display("Caption set ID")]
    public string CaptionSetId { get; set; }
}