using Apps.CaptionHub.Api;
using Apps.CaptionHub.Constants;
using Apps.CaptionHub.Invocables;
using Apps.CaptionHub.Models.Entities;
using Apps.CaptionHub.Models.Response.Team;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;
using RestSharp;

namespace Apps.CaptionHub.Actions;

public class TeamActions : CaptionHubInvocable
{
    public TeamActions(InvocationContext invocationContext) : base(invocationContext)
    {
    }
    
    [Action("List teams", Description = "List all teams the API user is a member of")]
    public async Task<ListTeamsRespnse> ListTeams()
    {
        var request = new CaptionHubRequest(ApiEndpoints.Teams, Method.Get, Creds);
        var response = await Client.ExecuteWithErrorHandling<TeamEntity[]>(request);

        return new(response);
    }
}