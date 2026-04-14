using Apps.CaptionHub.DataSourceHandlers;
using Apps.CaptionHub.DataSourceHandlers.EnumHandleres;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dictionaries;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Newtonsoft.Json;

namespace Apps.CaptionHub.Models.Request.Project;

public class SearchProjectsRequest
{
    [Display("Archived")]
    [JsonProperty("archived")]
    public bool? Archived { get; set; }

    [Display("Created by")]
    [JsonProperty("created_by")]
    public string? CreatedBy { get; set; }

    [Display("Duration")]
    [JsonProperty("duration")]
    [StaticDataSource(typeof(ProjectDurationDataHandler))]
    public string? Duration { get; set; }

    [Display("Filter text")]
    [JsonProperty("filter_text")]
    public string? FilterText { get; set; }

    [Display("Folder slug")]
    [DataSource(typeof(FolderDataHandler))]
    [JsonIgnore]
    public IEnumerable<string>? FolderSlug { get; set; }

    [Display("Include all subfolders")]
    [JsonIgnore]
    public bool? IncludeAllSubfolders { get; set; }

    [Display("Original language")]
    [JsonProperty("original_language")]
    [DataSource(typeof(LanguageCodeDataHandler))]
    public string? OriginalLanguage { get; set; }

    [Display("Platform")]
    [JsonProperty("platform")]
    [StaticDataSource(typeof(ProjectPlatformDataHandler))]
    public string? Platform { get; set; }

    [Display("Produced by")]
    [JsonProperty("produced_by")]
    public string? ProducedBy { get; set; }

    [Display("Tags")]
    [JsonProperty("tags")]
    public string? Tags { get; set; }

    [Display("Translation language")]
    [JsonProperty("translation_language")]
    [DataSource(typeof(LanguageCodeDataHandler))]
    public string? TranslationLanguage { get; set; }
}
