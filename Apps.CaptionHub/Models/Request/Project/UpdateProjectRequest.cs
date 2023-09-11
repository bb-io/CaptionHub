using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.CaptionHub.Models.Request.Project;

public class UpdateProjectRequest
{
    [Display("Slug")] public string? Slug { get; set; }

    [Display("Name")] public string? Name { get; set; }

    [Display("List of tags (comma-separated, double-quoted)")]
    [JsonProperty("tag_list")]
    public string? TagList { get; set; }
    
    [Display("Video title")]
    public string? VideoTitle { get; set; }

    [Display("Description")]
    public string? Description { get; set; }
    
    [Display("Speaker ID")]
    public string? SpeakerId { get; set; }

    [Display("Duration")]
    public string? Duration { get; set; }
    
    [Display("Frame rate")]
    public decimal? Framerate { get; set; }

    [Display("Original captions workflow type")]
    public string? OriginalCaptionsWorkflowType { get; set; }

    [Display("Translations workflow type")]
    public string? TranslationsWorkflowType { get; set; }

    [Display("Width")]
    public string? Width { get; set; }

    [Display("Height")]
    public string? Height { get; set; }

    [Display("Notes")]
    public string? Notes { get; set; }

    [Display("Timecode start")]
    public string? TimecodeStartstring { get; set; }
    
    [Display("Word Count")]
    public string? WordCount { get; set; }
}