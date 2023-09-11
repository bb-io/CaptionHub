using Apps.CaptionHub.Api;
using Apps.CaptionHub.Constants;
using Apps.CaptionHub.Invocables;
using Apps.CaptionHub.Models.Entities;
using Apps.CaptionHub.Models.Request.Workflow;
using Apps.CaptionHub.Models.Response.Workflow;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Utils.Extensions.String;
using RestSharp;

namespace Apps.CaptionHub.Actions;

[ActionList]
public class WorkflowActions : CaptionHubInvocable
{
    public WorkflowActions(InvocationContext invocationContext) : base(invocationContext)
    {
    }
        
    [Action("List workflow transitions", Description = "List all workflow transitions")]
    public async Task<ListWorkflowTransitionsResponse> ListWorkflowTransitions(
        [ActionParameter] ListWorkflowTransitionsRequest input)
    {
        var endpoint = ApiEndpoints.WorkflowTransitions.WithQuery(input);
        var request = new CaptionHubRequest(endpoint, Method.Get, Creds);
        
        var response = await Client.Paginate<WorkflowTransitionEntity>(request);
        return new(response);
    }
}