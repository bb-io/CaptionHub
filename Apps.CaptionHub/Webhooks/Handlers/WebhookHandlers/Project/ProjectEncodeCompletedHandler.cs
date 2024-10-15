using Apps.CaptionHub.Api;
using Apps.CaptionHub.Constants;
using Apps.CaptionHub.Models.Entities;
using Apps.CaptionHub.Webhooks.Handlers.WebhookHandlers.Base;
using Apps.CaptionHub.Webhooks.Models.Inputs;
using Apps.CaptionHub.Webhooks.Models.Responses;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Common.Webhooks;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace Apps.CaptionHub.Webhooks.Handlers.WebhookHandlers.Project;

public class ProjectEncodeCompletedHandler : CaptionHubWebhookHandler,
    IAfterSubscriptionWebhookEventHandler<ProjectWebhookResponse>
{
    private readonly ProjectWebhookInput _input;
    protected override string Event => "project.encode_completed";

    public ProjectEncodeCompletedHandler(InvocationContext invocationContext,
        [WebhookParameter] ProjectWebhookInput input) : base(invocationContext)
    {
        _input = input;
    }

    public async Task<AfterSubscriptionEventResponse<ProjectWebhookResponse>> OnWebhookSubscribedAsync()
    {
        if (_input.ProjectId is null)
            return null;

        var projectEndpoint = $"{ApiEndpoints.Projects}/{_input.ProjectId}";
        var projectRequest = new CaptionHubRequest(projectEndpoint, Method.Get, Creds);

        var project = await Client.ExecuteWithErrorHandling<ProjectEntityWithCaptionSets>(projectRequest);

        if (project.OriginalCaptionSet is null || !project.OriginalCaptionSet.Ready)
            return null;

        return new()
        {
            Result = new()
            {
                Project = new(project)
            }
        };
    }
}