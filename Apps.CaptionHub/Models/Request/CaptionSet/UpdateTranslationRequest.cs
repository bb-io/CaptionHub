using Apps.CaptionHub.DataSourceHandlers;
using Apps.CaptionHub.Models.Request.Project;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Files;
using Newtonsoft.Json;

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
    
    public FileReference File { get; set; }
}