using Blackbird.Applications.Sdk.Common;

namespace Apps.CaptionHub.Models.Entities;

public class AutomationEntity
{
    [Display("Automation ID")]
    public string Id { get; set; }
    
    public string Name { get; set; }
}