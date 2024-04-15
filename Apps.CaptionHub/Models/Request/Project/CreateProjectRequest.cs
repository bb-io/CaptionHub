using Apps.CaptionHub.DataSourceHandlers;
using Apps.CaptionHub.DataSourceHandlers.EnumHandleres;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dictionaries;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Newtonsoft.Json;

namespace Apps.CaptionHub.Models.Request.Project;

public class CreateProjectRequest
{
    [JsonProperty("name")] public string Name { get; set; }

    [Display("Video title")]
    [JsonProperty("video_title")]
    public string? VideoTitle { get; set; }

    [JsonProperty("description")] public string? Description { get; set; }

    [Display("List of tags (comma-separated, double-quoted)")]
    [JsonProperty("tag_list")]
    public string? TagList { get; set; }

    [Display("Speaker ID")]
    [JsonProperty("speaker_id")]
    public string? SpeakerId { get; set; }

    [Display("Remote media URL")]
    [JsonProperty("remote_media_url")]
    public string? RemoteMediaUrl { get; set; }

    [Display("Thumbnail URL")]
    [JsonProperty("thumbnail_url")]
    public string? ThumbnailUrl { get; set; }

    [JsonProperty("duration")] public int? Duration { get; set; }

    [Display("Languages (comma-separated)")]
    [JsonProperty("language_codes")]
    public string? LanguageCodes { get; set; }

    [JsonProperty("notes")] public string? Notes { get; set; }

    [Display("Lock timeline")]
    [JsonProperty("lock_timeline")]
    public bool? LockTimeline { get; set; }

    [Display("Override framerate")]
    [JsonProperty("override_framerate")]
    [StaticDataSource(typeof(OverrideFramerateDataHandler))]
    public string? OverrideFramerate { get; set; }

    [Display("Automation ID")]
    [JsonProperty("automation_id")]
    [DataSource(typeof(AutomationDataHandler))]
    public string? AutomationId { get; set; }

    [Display("Original captions workflow type")]
    [JsonProperty("original_captions_workflow_type")]
    [StaticDataSource(typeof(WorkflowTypeDataHandler))]
    public string? OriginalCaptionsWorkflowType { get; set; }

    [Display("Translations workflow type")]
    [JsonProperty("translations_workflow_type")]
    [StaticDataSource(typeof(WorkflowTypeDataHandler))]
    public string? TranslationsWorkflowType { get; set; }

    [Display("Timecode start (SMPTE format, e.g., '10:00:00:00')")]
    [JsonProperty("timecode_start_string")]
    public string? TimecodeStartString { get; set; }

    [Display("Status callback URL")]
    [JsonProperty("status_callback_url")]
    public string? StatusCallbackUrl { get; set; }

    [Display("Termbase IDs (comma-separated)")]
    [JsonProperty("termbase_ids")]
    public string? TermbaseIds { get; set; }
}