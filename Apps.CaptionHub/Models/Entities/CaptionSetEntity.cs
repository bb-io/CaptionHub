using Blackbird.Applications.Sdk.Common;

namespace Apps.CaptionHub.Models.Entities;

public class CaptionSetEntity
{
    [Display("Catpion set ID")]
    public string Id { get; set; }

    [Display("Language")]
    public LanguageEntity Language { get; set; }

    [Display("Translated speaker ID")]
    public string TranslatedSpeakerId { get; set; }

    [Display("Percentage complete")]
    public double PercentageComplete { get; set; }

    [Display("Maximum line count")]
    public int MaximumLineCount { get; set; }

    [Display("Minimum caption duration")]
    public float MinimumCaptionDuration { get; set; }

    [Display("Maximum caption duration")]
    public float MaximumCaptionDuration { get; set; }

    [Display("Maximum character count")]
    public int MaximumCharacterCount { get; set; }

    [Display("Minimum frames between captions")]
    public int MinimumFramesBetweenCaptions { get; set; }

    [Display("Ready")]
    public string Ready { get; set; }

    [Display("Latest snapshot ID")]
    public string LatestSnapshotId { get; set; }

    [Display("Segments")]
    public SegmentEntity[]? Segments { get; set; }

    [Display("Renderings")]
    public RenderingEntity[]? Renderings { get; set; }
}