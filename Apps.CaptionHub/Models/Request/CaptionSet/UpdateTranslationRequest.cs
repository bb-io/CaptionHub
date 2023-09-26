using Apps.CaptionHub.DataSourceHandlers;
using Apps.CaptionHub.Models.Request.Project;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Newtonsoft.Json;
using File = Blackbird.Applications.Sdk.Common.Files.File;

namespace Apps.CaptionHub.Models.Request.CaptionSet;

public class UpdateTranslationRequest : ProjectRequest
{
    [Display("Language ID")]
    [DataSource(typeof(LanguageIdDataHandler))]
    public string? LanguageId { get; set; }
    
    [Display("Language code")]
    [JsonProperty("language_code")]
    [DataSource(typeof(LanguageCodeDataHandler))]
    public string? LanguageCode { get; set; }
    
    public File File { get; set; }
}