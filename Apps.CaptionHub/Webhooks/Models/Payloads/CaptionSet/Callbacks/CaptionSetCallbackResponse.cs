using Apps.CaptionHub.Webhooks.Models.Payloads.Project.Callbacks;
using Newtonsoft.Json;

namespace Apps.CaptionHub.Webhooks.Models.Payloads.CaptionSet.Callbacks;

public class CaptionSetCallbackResponse
{
    [JsonProperty("project")]
    public FullProjectCallbackPayload Project { get; set; }

    [JsonProperty("caption_set")]
    public CaptionSetCallbackPayload CaptionSet { get; set; }
}