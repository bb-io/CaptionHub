using Blackbird.Applications.Sdk.Utils.Sdk.DataSourceHandlers;

namespace Apps.CaptionHub.DataSourceHandlers.EnumHandleres;

public class TranscriptionProviderDataHandler : EnumDataHandler
{
    protected override Dictionary<string, string> EnumValues => new()
    {
        { "aws", "AWS" },
        { "speechmatics_v2", "Speechmatics V2" }
    };
}