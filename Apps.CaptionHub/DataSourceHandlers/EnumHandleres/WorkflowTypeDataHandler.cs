using Blackbird.Applications.Sdk.Common.Dictionaries;

namespace Apps.CaptionHub.DataSourceHandlers.EnumHandleres;

public class WorkflowTypeDataHandler : IStaticDataSourceHandler
{
    public Dictionary<string, string> GetData() => new()
    {
        { "assignable", "Assignable" },
        { "assignable_review", "Assignable review" },
        { "self_serve", "Self serve" },
        { "self_serve_review", "Self serve review" },
        { "solo", "Solo" },
    };
}