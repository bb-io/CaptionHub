using Apps.CaptionHub.Models.Response.CustomDictionary;
using Blackbird.Applications.Sdk.Common;

namespace Apps.CaptionHub.Models.Entities;

public class CustomDictionaryEntity
{
    [Display("Custom dictionary ID")] public string Id { get; set; }

    [Display("Name")] public string Name { get; set; }

    [Display("Language name")] public string LanguageName { get; set; }

    [Display("Language tag")] public string LanguageTag { get; set; }

    [Display("Providers")] public IEnumerable<string> Providers { get; set; }

    public CustomDictionaryEntity(CustomDictionaryResponse response)
    {
        Id = response.Id;
        Name = response.Name;
        LanguageName = response.LanguageName;
        LanguageTag = response.LanguageTag;
        Providers = response.ProviderIds.Select(x => x.Key);
    }
}