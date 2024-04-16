using Blackbird.Applications.Sdk.Common.Dictionaries;

namespace Apps.CaptionHub.DataSourceHandlers.EnumHandleres;

public class UserRoleDataHandler : IStaticDataSourceHandler
{
    public Dictionary<string, string> GetData()
        => new()
        {
            { "linguist", "Linguist" },
            { "reviewer", "Reviewer" },
            { "producer", "Producer" },
            { "language_supervisor", "Language supervisor" },
            { "superuser", "Superuser" },
        };
}