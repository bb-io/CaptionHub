using Apps.CaptionHub.Webhooks.Models.Payloads.Language;
using Blackbird.Applications.Sdk.Common;

namespace Apps.CaptionHub.Webhooks.Models.Payloads.CaptionSet.Callbacks;

public class CaptionSetCallbackPayload
{
    [Display("Caption set ID")]
    public string CaptionSetId { get; set; }
    
    public LanguageCallbackPayload Language { get; set; }
}