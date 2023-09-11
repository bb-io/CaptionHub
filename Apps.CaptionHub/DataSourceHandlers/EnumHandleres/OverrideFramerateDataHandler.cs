using Blackbird.Applications.Sdk.Utils.Sdk.DataSourceHandlers;

namespace Apps.CaptionHub.DataSourceHandlers.EnumHandleres;

public class OverrideFramerateDataHandler : EnumDataHandler
{
    protected override Dictionary<string, string> EnumValues => new()
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