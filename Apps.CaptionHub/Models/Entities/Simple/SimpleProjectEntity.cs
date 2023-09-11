using Blackbird.Applications.Sdk.Common;

namespace Apps.CaptionHub.Models.Entities.Simple;

public class SimpleProjectEntity
{
    [Display("Project ID")]
    public string Id { get; set; }
    
    [Display("Project name")]
    public string Name { get; set; }
    
    [Display("Video title")]
    public string VideoTitle { get; set; }
}