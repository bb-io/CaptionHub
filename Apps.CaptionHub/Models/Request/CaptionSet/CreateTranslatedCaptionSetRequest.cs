using Apps.CaptionHub.DataSourceHandlers;
using Apps.CaptionHub.DataSourceHandlers.EnumHandleres;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dictionaries;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Newtonsoft.Json;

namespace Apps.CaptionHub.Models.Request.CaptionSet;

public class CreateTranslatedCaptionSetRequest
{
    [Display("Project")]
    [JsonProperty("project_id")]
    [DataSource(typeof(ProjectDataHandler))]
    public string ProjectId { get; set; }
    
    [Display("Language ID")]
    [JsonProperty("language_id")]
    [DataSource(typeof(LanguageIdDataHandler))]
    public string? LanguageId { get; set; }
    
    [Display("Language code")]
    [JsonProperty("language_code")]
    [DataSource(typeof(LanguageCodeDataHandler))]
    public string? LanguageCode { get; set; }
    
    [JsonProperty("autotranslation")]
    public bool? Autotranslation { get; set; }

    [Display("Translation provider")]
    [JsonProperty("translation_provider")]
    [StaticDataSource(typeof(TranslationProviderDataHandler))]
    public string? TranslationProvider { get; set; }
}