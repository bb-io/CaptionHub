using Blackbird.Applications.Sdk.Utils.Sdk.DataSourceHandlers;

namespace Apps.CaptionHub.DataSourceHandlers.EnumHandleres;

public class TranslationProviderDataHandler : EnumDataHandler
{
    protected override Dictionary<string, string> EnumValues => new()
    {
        { "amazon", "Amazon" },
        { "gengo", "Gengo" },
        { "google", "Google" },
        { "systran", "Systran" }
    };
}