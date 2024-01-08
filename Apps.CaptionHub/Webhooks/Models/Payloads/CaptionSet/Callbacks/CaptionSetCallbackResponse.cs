using Apps.CaptionHub.Webhooks.Models.Payloads.Project.Callbacks;

namespace Apps.CaptionHub.Webhooks.Models.Payloads.CaptionSet.Callbacks;

public class CaptionSetCallbackResponse
{
    public FullProjectCallbackPayload Project { get; set; }
    public CaptionSetCallbackPayload CaptionSet { get; set; }
}