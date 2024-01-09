using Blackbird.Applications.Sdk.Common;

namespace Apps.CaptionHub.Webhooks.Models.Payloads.Language;

public class LanguagePayload
{
    [Display("Language ID")]
    public string Id { get; set; }
    
    [Display("Language name")]
    public string Name { get; set; }
    
    [Display("Code and territory")]
    public string CodeAndTerritory { get; set; }
}