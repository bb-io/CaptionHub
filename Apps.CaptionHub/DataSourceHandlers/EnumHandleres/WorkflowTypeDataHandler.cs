using Blackbird.Applications.Sdk.Utils.Sdk.DataSourceHandlers;

namespace Apps.CaptionHub.DataSourceHandlers.EnumHandleres;

public class WorkflowTypeDataHandler : EnumDataHandler
{
    protected override Dictionary<string, string> EnumValues => new()
    {
        { "assignable", "Assignable" },
        { "assignable_review", "Assignable review" },
        { "self_serve", "Self serve" },
        { "self_serve_review", "Self serve review" },
        { "solo", "Solo" },
    };
}