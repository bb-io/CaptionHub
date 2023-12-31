using Apps.CaptionHub.Api;
using Apps.CaptionHub.Constants;
using Apps.CaptionHub.Invocables;
using Apps.CaptionHub.Models.Response.CustomDictionary;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Invocation;
using RestSharp;

namespace Apps.CaptionHub.DataSourceHandlers;

public class CustomDictionaryDataHandler : CaptionHubInvocable, IAsyncDataSourceHandler
{
    public CustomDictionaryDataHandler(InvocationContext invocationContext) : base(invocationContext)
    {
    }

    public async Task<Dictionary<string, string>> GetDataAsync(
        DataSourceContext context, CancellationToken cancellationToken)
    {
        var request = new CaptionHubRequest(ApiEndpoints.CustomDictionary, Method.Get, Creds);
        var response = await Client.ExecuteWithErrorHandling<CustomDictionaryResponse[]>(request);

        return response
            .Where(x => context.SearchString is null ||
                        x.Name.Contains(context.SearchString, StringComparison.OrdinalIgnoreCase))
            .ToDictionary(x => x.Id, x => x.Name);
    }
}