using Blackbird.Applications.Sdk.Common.Dictionaries;

namespace Apps.CaptionHub.DataSourceHandlers.EnumHandleres;

public class SplitTextFileOnHandler : IStaticDataSourceHandler
{
    public Dictionary<string, string> GetData()
     => new()
    {
        {"smart_audio", "Smart audio"},
        {"sentences", "Sentences"},
        {"linebreaks", "Linebreaks"},
    };
}