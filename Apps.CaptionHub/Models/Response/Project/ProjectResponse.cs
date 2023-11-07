using Apps.CaptionHub.Models.Entities;

namespace Apps.CaptionHub.Models.Response.Project;

public class ProjectResponse
{
    public string Id { get; set; }

    public string Slug { get; set; }

    public string Name { get; set; }

    public string[] TagList { get; set; }

    public string VideoTitle { get; set; }

    public string Description { get; set; }

    public string SpeakerId { get; set; }

    public string Duration { get; set; }

    public decimal? Framerate { get; set; }

    public string OriginalCaptionsWorkflowType { get; set; }

    public string TranslationsWorkflowType { get; set; }

    public string Width { get; set; }

    public string Height { get; set; }

    public string Notes { get; set; }

    public string TimecodeStartString { get; set; }
    
    public CaptionSetEntity? OriginalCaptionSet { get; set; }

    public string WordCount { get; set; }
}