using Blackbird.Applications.Sdk.Common;

namespace Apps.CaptionHub.Models.Entities;

public class ProjectEntityWithCaptionSets : ProjectEntity
{
    [Display("Original caption set")]
    public CaptionSetEntity? OriginalCaptionSet { get; set; }

    [Display("Caption sets")] public CaptionSetEntity[] CaptionSets { get; set; }
}