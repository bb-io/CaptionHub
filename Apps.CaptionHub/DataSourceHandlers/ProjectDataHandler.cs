using Apps.CaptionHub.Api;
using Apps.CaptionHub.Constants;
using Apps.CaptionHub.Invocables;
using Apps.CaptionHub.Models.Entities;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Invocation;
using RestSharp;

namespace Apps.CaptionHub.DataSourceHandlers;

public class ProjectDataHandler : CaptionHubInvocable, IAsyncDataSourceHandler
{
    public ProjectDataHandler(InvocationContext invocationContext) : base(invocationContext)
    {
    }

    public async Task<Dictionary<string, string>> GetDataAsync(
        DataSourceContext context, CancellationToken cancellationToken)
    {
        var request = new CaptionHubRequest(ApiEndpoints.Projects, Method.Get, Creds);
        var response = await Client.Paginate<ProjectEntity>(request);

        return response
            .Where(x => context.SearchString is null ||
                        x.Name.Contains(context.SearchString, StringComparison.OrdinalIgnoreCase))
            .Take(30)
            .ToDictionary(x => x.Id, x => x.Name);
    }
}