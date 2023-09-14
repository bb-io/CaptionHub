using Blackbird.Applications.Sdk.Common;

namespace Apps.CaptionHub.Webhooks.Models.Payloads.CaptionSet;

public class CaptionSetPayload
{
    [Display("Caption set ID")]
    public string CaptionSetId { get; set; }
    
    public LanguagePayload Language { get; set; }
}