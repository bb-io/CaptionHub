using Apps.CaptionHub.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Newtonsoft.Json;

namespace Apps.CaptionHub.Models.Request.CaptionSet;

public class CreateTranslatedCaptionSetRequest
{
    [Display("Project ID")]
    [JsonProperty("project_id")]
    public string ProjectId { get; set; }
    
    [Display("Language ID")]
    [JsonProperty("language_id")]
    [DataSource(typeof(LanguageDataHandler))]
    public string LanguageId { get; set; }
    
    [JsonProperty("autotranslation")]
    public bool? Autotranslation { get; set; }
}