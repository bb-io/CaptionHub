using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.CaptionHub.Webhooks.Models.Payloads.Language;

public class LanguageCallbackPayload
{
    [Display("Language name")]
    [JsonProperty("name")]
    public string LanguageName { get; set; }

    public string Code { get; set; }
}