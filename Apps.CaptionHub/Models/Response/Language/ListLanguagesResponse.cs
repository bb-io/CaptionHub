using Apps.CaptionHub.Models.Entities;

namespace Apps.CaptionHub.Models.Response.Language;

public record ListLanguagesResponse(LanguageEntity[] Languages);