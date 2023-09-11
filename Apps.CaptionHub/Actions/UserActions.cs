using Apps.CaptionHub.Api;
using Apps.CaptionHub.Constants;
using Apps.CaptionHub.Invocables;
using Apps.CaptionHub.Models.Entities;
using Apps.CaptionHub.Models.Response.User;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;
using RestSharp;

namespace Apps.CaptionHub.Actions;

public class UserActions : CaptionHubInvocable
{
    public UserActions(InvocationContext invocationContext) : base(invocationContext)
    {
    }

    [Action("List users", Description = "List team users")]
    public async Task<ListUsersResponse> ListUsers()
    {
        var request = new CaptionHubRequest(ApiEndpoints.Users, Method.Get, Creds);
        var response = await Client.ExecuteWithErrorHandling<UserEntity[]>(request);

        return new(response);
    }
}