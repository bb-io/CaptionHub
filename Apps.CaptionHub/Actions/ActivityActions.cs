using Apps.CaptionHub.Api;
using Apps.CaptionHub.Constants;
using Apps.CaptionHub.Invocables;
using Apps.CaptionHub.Models.Entities;
using Apps.CaptionHub.Models.Request.Activity;
using Apps.CaptionHub.Models.Response.Activity;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Utils.Extensions.String;
using RestSharp;

namespace Apps.CaptionHub.Actions;

[ActionList]
public class ActivityActions : CaptionHubInvocable
{
    public ActivityActions(InvocationContext invocationContext) : base(invocationContext)
    {
    }
    
    [Action("List activities", Description = "List all activities")]
    public async Task<ListActivitiesResponse> ListActivities([ActionParameter] ListActivitiesRequest query)
    {
        var endpoint = ApiEndpoints.Activities.WithQuery(query);
        var request = new CaptionHubRequest(endpoint, Method.Get, Creds);
        
        var response = await Client.Paginate<ActivityEntity>(request);
        return new(response);
    }
}