using Blackbird.Applications.Sdk.Common;

namespace Apps.CaptionHub.Models.Entities;

public class TeamEntity
{
    [Display("Team ID")]
    public string Id { get; set; }
    
    public string Name { get; set; }
    
    [Display("Default original captions workflow type")]
    public string DefaultOriginalCaptionsWorkflowType { get; set; }
    
    [Display("Default translations workflow type")]
    public string DefaultTranslationsWorkflowType { get; set; }
}