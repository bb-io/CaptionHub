using Blackbird.Applications.Sdk.Common.Dictionaries;

namespace Apps.CaptionHub.DataSourceHandlers.EnumHandleres;

public class TranslationProviderDataHandler : IStaticDataSourceHandler
{
    public Dictionary<string, string> GetData()
        => new()
        {
            { "amazon", "Amazon" },
            { "gengo", "Gengo" },
            { "google", "Google" },
            { "systran", "Systran" }
        };
}