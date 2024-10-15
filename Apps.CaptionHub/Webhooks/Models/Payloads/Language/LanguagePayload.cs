using Apps.CaptionHub.Models.Entities;
using Blackbird.Applications.Sdk.Common;

namespace Apps.CaptionHub.Webhooks.Models.Payloads.Language;

public class LanguagePayload
{
    [Display("Language ID")] public string Id { get; set; }

    [Display("Language name")] public string Name { get; set; }

    [Display("Code and territory")] public string CodeAndTerritory { get; set; }

    public LanguagePayload()
    {
    }

    public LanguagePayload(LanguageEntity languageEntity)
    {
        Id = languageEntity.Id;
        Name = languageEntity.Name;
        CodeAndTerritory = languageEntity.CodeAndTerritory;
    }
}