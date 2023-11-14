using Apps.CaptionHub.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.CaptionHub.Models.Request.CustomDictionary;

public class CustomDictionaryRequest
{
    [Display("Custom dictionary")]
    [DataSource(typeof(CustomDictionaryDataHandler))]
    public string CustomDictionaryId { get; set; }
}