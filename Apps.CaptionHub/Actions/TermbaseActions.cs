using Apps.CaptionHub.Api;
using Apps.CaptionHub.Constants;
using Apps.CaptionHub.Invocables;
using Apps.CaptionHub.Models.Entities;
using Apps.CaptionHub.Models.Response.Termbase;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;
using RestSharp;

namespace Apps.CaptionHub.Actions;

[ActionList]
public class TermbaseActions : CaptionHubInvocable
{
    public TermbaseActions(InvocationContext invocationContext) : base(invocationContext)
    {
    }
    
    [Action("List termbases", Description = "List user's team termbases")]
    public async Task<ListTermbasesResponse> ListTermbases()
    {
        var request = new CaptionHubRequest(ApiEndpoints.Termbases, Method.Get, Creds);
        var response = await Client.ExecuteWithErrorHandling<TermbaseEntity[]>(request);

        return new(response);
    }
}