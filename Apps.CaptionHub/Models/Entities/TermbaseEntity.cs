using Blackbird.Applications.Sdk.Common;

namespace Apps.CaptionHub.Models.Entities;

public class TermbaseEntity
{
    [Display("Termbase ID")]
    public string Id { get; set; }
    
    public string Name { get; set; }
    
    public LanguageEntity[] Languages { get; set; }
}