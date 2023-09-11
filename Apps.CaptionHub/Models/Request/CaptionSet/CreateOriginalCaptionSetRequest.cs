﻿using Apps.CaptionHub.DataSourceHandlers;
using Apps.CaptionHub.DataSourceHandlers.EnumHandleres;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Newtonsoft.Json;

namespace Apps.CaptionHub.Models.Request.CaptionSet;

public class CreateOriginalCaptionSetRequest
{
    [Display("Project ID")]
    [JsonProperty("project_id")]
    public string ProjectId { get; set; }

    [Display("User transcription")]
    [JsonProperty("transcription")]
    public bool? Transcription { get; set; }

    [Display("Split text file on")]
    [JsonProperty("split_text_file_on")]
    [DataSource(typeof(SplitTextFileOnHandler))]
    public string? SplitTextFileOn { get; set; }

    [Display("Language ID")]
    [JsonProperty("language_id")]
    [DataSource(typeof(LanguageDataHandler))]
    public string? LanguageId { get; set; }

    [Display("Maximum line count")]
    [JsonProperty("maximum_line_count")]
    public string? MaxLineCount { get; set; }

    [Display("Minimum caption duration")]
    [JsonProperty("minimum_caption_duration")]
    public float? MinCaptionDuration { get; set; }

    [Display("Maximum caption duration")]
    [JsonProperty("maximum_caption_duration")]
    public float? MaxCaptionDuration { get; set; }

    [Display("Maximum character count")]
    [JsonProperty("maximum_character_count")]
    public int? MaximumCharacterCount { get; set; }

    [Display("Minimum frames between captions")]
    [JsonProperty("minimum_frames_between_captions")]
    public int? MinimumFramesBetweenCaptions { get; set; }
}