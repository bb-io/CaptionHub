using Apps.CaptionHub.Webhooks.Models.Payloads.Project;

namespace Apps.CaptionHub.Webhooks.Models.Payloads.CaptionSet;

public class CaptionSetEventPayload
{
    public FullProjectPayload Project { get; set; }
    public CaptionSetPayload CaptionSet { get; set; }
}