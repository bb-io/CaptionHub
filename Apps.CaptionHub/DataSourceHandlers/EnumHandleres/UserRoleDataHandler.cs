using Blackbird.Applications.Sdk.Utils.Sdk.DataSourceHandlers;

namespace Apps.CaptionHub.DataSourceHandlers.EnumHandleres;

public class UserRoleDataHandler : EnumDataHandler
{
    protected override Dictionary<string, string> EnumValues => new()
    {
        { "linguist", "Linguist" },
        { "reviewer", "Reviewer" },
        { "producer", "Producer" },
        // TODO: check if role works
        { "language supervisor", "Language supervisor" },
        { "superuser", "Superuser" },
    };
}