using Blackbird.Applications.Sdk.Common;

namespace Apps.CaptionHub.Models.Entities;

public class ProjectEntity
{
    [Display("Project ID")]
    public string Id { get; set; }

    [Display("Slug")]
    public string Slug { get; set; }

    [Display("Name")]
    public string Name { get; set; }

    [Display("Tag list")]
    public string[] TagList { get; set; }

    [Display("Video title")]
    public string VideoTitle { get; set; }

    [Display("Description")]
    public string Description { get; set; }

    [Display("Speaker ID")]
    public string SpeakerId { get; set; }

    [Display("Duration")]
    public string Duration { get; set; }

    [Display("Frame rate")]
    public decimal? Framerate { get; set; }

    [Display("Original captions workflow type")]
    public string OriginalCaptionsWorkflowType { get; set; }

    [Display("Translations workflow type")]
    public string TranslationsWorkflowType { get; set; }

    [Display("Width")]
    public string Width { get; set; }

    [Display("Height")]
    public string Height { get; set; }

    [Display("Notes")]
    public string Notes { get; set; }

    [Display("Timecode start")]
    public string TimecodeStartString { get; set; }

    [Display("Original Caption Set")]
    public CaptionSetEntity OriginalCaptionSet { get; set; }

    [Display("Caption Sets")]
    public CaptionSetEntity[] CaptionSets { get; set; }

    [Display("Word Count")]
    public string WordCount { get; set; }
}