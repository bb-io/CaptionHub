using Blackbird.Applications.Sdk.Common;

namespace Apps.CaptionHub.Models.Entities.Simple;

public class SimpleCaptionSetEntity
{
    [Display("Caption set ID")]
    public string Id { get; set; }
    
    [Display("Language code")]
    public string LanguageCode { get; set; }
}