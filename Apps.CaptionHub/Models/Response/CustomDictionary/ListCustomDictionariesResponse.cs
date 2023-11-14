using Apps.CaptionHub.Models.Entities;

namespace Apps.CaptionHub.Models.Response.CustomDictionary;

public record ListCustomDictionariesResponse(CustomDictionaryEntity[] Dictionaries);