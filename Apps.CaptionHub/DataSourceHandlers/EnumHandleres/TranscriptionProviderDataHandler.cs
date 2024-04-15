using Blackbird.Applications.Sdk.Common.Dictionaries;

namespace Apps.CaptionHub.DataSourceHandlers.EnumHandleres;

public class TranscriptionProviderDataHandler : IStaticDataSourceHandler
{
    public Dictionary<string, string> GetData()
        => new()
        {
            { "aws", "AWS" },
            { "speechmatics_v2", "Speechmatics V2" }
        };
}