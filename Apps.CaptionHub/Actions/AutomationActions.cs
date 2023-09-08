using Apps.CaptionHub.Api;
using Apps.CaptionHub.Constants;
using Apps.CaptionHub.Invocables;
using Apps.CaptionHub.Models.Entities;
using Apps.CaptionHub.Models.Response.Automation;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;
using RestSharp;

namespace Apps.CaptionHub.Actions;

[ActionList]
public class AutomationActions : CaptionHubInvocable
{
    public AutomationActions(InvocationContext invocationContext)
        : base(invocationContext)
    {
    }

    [Action("List automations", Description = "List all automations that can be applied to a project on creation")]
    public async Task<ListAutomationsResponse> ListAutomations()
    {
        var request = new CaptionHubRequest(ApiEndpoints.Automations, Method.Get, Creds);
        var response = await Client.ExecuteWithErrorHandling<AutomationEntity[]>(request);

        return new(response);
    }
}