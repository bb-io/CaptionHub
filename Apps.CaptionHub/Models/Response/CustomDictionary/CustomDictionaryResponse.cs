namespace Apps.CaptionHub.Models.Response.CustomDictionary;

public class CustomDictionaryResponse
{
    public string Id { get; set; }
    
    public string Name { get; set; }
    
    public string LanguageName { get; set; }
    
    public string LanguageTag { get; set; }
    
    public Dictionary<string, string> ProviderIds { get; set; }
}