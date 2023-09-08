using Blackbird.Applications.Sdk.Common;

namespace Apps.CaptionHub.Models.Entities;

public class LanguageEntity
{
    [Display("Language ID")]
    public string Id { get; set; }
    
    public string Name { get; set; }
    
    [Display("Code and territory")]
    public string CodeAndTerritory { get; set; }
    
    [Display("Territory and code")]
    public string TerritoryAndCode { get; set; }
    
    [Display("Auto align available")]
    public string AutoAlignAvailable { get; set; }
    
    [Display("Auto transcribe available")]
    public string AutoTranscribeAvailable { get; set; }
}