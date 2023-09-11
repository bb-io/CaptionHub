using Blackbird.Applications.Sdk.Utils.Sdk.DataSourceHandlers;

namespace Apps.CaptionHub.DataSourceHandlers.EnumHandleres;

public class SplitTextFileOnHandler : EnumDataHandler
{
    protected override Dictionary<string, string> EnumValues => new()
    {
        {"smart_audio", "Smart audio"},
        {"sentences", "Sentences"},
        {"linebreaks", "Linebreaks"},
    };
}