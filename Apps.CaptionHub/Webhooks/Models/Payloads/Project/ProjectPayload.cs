using Apps.CaptionHub.Webhooks.Models.Payloads.CaptionSet;
using Blackbird.Applications.Sdk.Common;

namespace Apps.CaptionHub.Webhooks.Models.Payloads.Project;

public class ProjectPayload
{
    [Display("Project ID")]
    public string Id { get; set; }

    [Display("Slug")]
    public string? Slug { get; set; }

    [Display("Name")]
    public string Name { get; set; }

    [Display("Video title")]
    public string? VideoTitle { get; set; }

    [Display("Description")]
    public string? Description { get; set; }

    [Display("Duration")]
    public decimal? Duration { get; set; }

    [Display("Framerate")]
    public double? Framerate { get; set; }

    [Display("Original captions workflow type")]
    public string? OriginalCaptionsWorkflowType { get; set; }

    [Display("Translations workflow type")]
    public string? TranslationsWorkflowType { get; set; }

    [Display("Width")]
    public int? Width { get; set; }

    [Display("Height")]
    public int? Height { get; set; }

    [Display("Notes")]
    public string? Notes { get; set; }

    [Display("Timecode start string")]
    public string? TimecodeStartString { get; set; }

    [Display("Original caption set")]
    public CaptionSetPayload? OriginalCaptionSet { get; set; }

    [Display("Caption sets")]
    public IEnumerable<CaptionSetPayload> CaptionSets { get; set; }

    [Display("Word count")]
    public int WordCount { get; set; }
}