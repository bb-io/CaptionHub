using Blackbird.Applications.Sdk.Common.Dictionaries;

namespace Apps.CaptionHub.DataSourceHandlers.EnumHandleres;

public class OverrideFramerateDataHandler : IStaticDataSourceHandler
{
    public Dictionary<string, string> GetData()
        => new()
        {
            { "23.976", "23.976" },
            { "24", "24" },
            { "25", "25" },
            { "29.97", "29.97" },
            { "30", "30" },
            { "50", "50" },
            { "59.94", "59.94" },
            { "60", "60" },
        };
}