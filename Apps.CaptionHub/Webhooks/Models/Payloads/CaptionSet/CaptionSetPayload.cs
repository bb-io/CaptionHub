using Apps.CaptionHub.Models.Entities;
using Apps.CaptionHub.Webhooks.Models.Payloads.Language;
using Blackbird.Applications.Sdk.Common;

namespace Apps.CaptionHub.Webhooks.Models.Payloads.CaptionSet;

public class CaptionSetPayload
{
    [Display("Caption set ID")] public string Id { get; set; }

    public bool Ready { get; set; }

    public LanguagePayload Language { get; set; }

    [Display("Percentage complete")] public int PercentageComplete { get; set; }

    [Display("Maximum line count")] public int? MaximumLineCount { get; set; }

    [Display("Minimum caption duration")] public float? MinimumCaptionDuration { get; set; }

    [Display("Maximum caption duration")] public float? MaximumCaptionDuration { get; set; }

    [Display("Maximum character count")] public int? MaximumCharacterCount { get; set; }

    [Display("Minimum frames between captions")]
    public int? MinimumFramesBetweenCaptions { get; set; }

    public CaptionSetPayload()
    {
    }

    public CaptionSetPayload(CaptionSetEntity captionSet)
    {
        Id = captionSet.Id;
        Ready = captionSet.Ready;
        Language = new LanguagePayload(captionSet.Language);
        PercentageComplete = (int)captionSet.PercentageComplete;
        MaximumLineCount = captionSet.MaximumLineCount != 0 ? captionSet.MaximumLineCount : null;
        MinimumCaptionDuration =
            captionSet.MinimumCaptionDuration != 0 ? captionSet.MinimumCaptionDuration : null;
        MaximumCaptionDuration =
            captionSet.MaximumCaptionDuration != 0 ? captionSet.MaximumCaptionDuration : null;
        MaximumCharacterCount = captionSet.MaximumCharacterCount != 0 ? captionSet.MaximumCharacterCount : null;
        MinimumFramesBetweenCaptions = captionSet.MinimumFramesBetweenCaptions != 0
            ? captionSet.MinimumFramesBetweenCaptions
            : null;
    }
}