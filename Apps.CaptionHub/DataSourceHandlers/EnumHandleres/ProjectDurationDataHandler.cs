using Blackbird.Applications.Sdk.Common.Dictionaries;

namespace Apps.CaptionHub.DataSourceHandlers.EnumHandleres;

public class ProjectDurationDataHandler : IStaticDataSourceHandler
{
    public Dictionary<string, string> GetData() => new()
    {
        { "0_1m", "0-1 minute" },
        { "1m_5m", "1-5 minutes" },
        { "5m_10m", "5-10 minutes" },
        { "10m_20m", "10-20 minutes" },
        { "20m_60m", "20-60 minutes" },
        { "1h_2h", "1-2 hours" },
        { "2h_100h", "2-100 hours" }
    };
}
