using Apps.CaptionHub.Api;
using Apps.CaptionHub.Constants;
using Apps.CaptionHub.Models.Entities;
using Apps.CaptionHub.Webhooks.Handlers.WebhookHandlers.Base;
using Apps.CaptionHub.Webhooks.Models.Inputs;
using Apps.CaptionHub.Webhooks.Models.Payloads.CaptionSet;
using Apps.CaptionHub.Webhooks.Models.Payloads.Project;
using Apps.CaptionHub.Webhooks.Models.Responses;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Common.Webhooks;
using RestSharp;

namespace Apps.CaptionHub.Webhooks.Handlers.WebhookHandlers.CaptionSet;

public class CaptionSetRenderedHandler : CaptionHubWebhookHandler,
    IAfterSubscriptionWebhookEventHandler<RenderingWebhookResponse>
{
    private readonly RenderWebhookInput _input;
    protected override string Event => "caption_set.rendered";

    public CaptionSetRenderedHandler(InvocationContext invocationContext, [WebhookParameter] RenderWebhookInput input) :
        base(invocationContext)
    {
        _input = input;
    }

    public async Task<AfterSubscriptionEventResponse<RenderingWebhookResponse>> OnWebhookSubscribedAsync()
    {
        if (_input.CaptionSetId is null || _input.RenderId is null)
            return null;

        var endpoint = $"{ApiEndpoints.CaptionSets}/{_input.CaptionSetId}/renders/{_input.RenderId}/status";
        var request = new CaptionHubRequest(endpoint, Method.Get, Creds);

        try
        {
            var response = await Client.ExecuteWithErrorHandling<RenderingEntity>(request);

            if (response.Status != "completed")
                return null;

            ProjectPayload? projectPayload = null;
            CaptionSetPayload? captionSetPayload = null;

            if (_input.ProjectId is not null)
            {
                var projectEndpoint = $"{ApiEndpoints.Projects}/{_input.ProjectId}";
                var projectRequest = new CaptionHubRequest(projectEndpoint, Method.Get, Creds);

                var project = await Client.ExecuteWithErrorHandling<ProjectEntityWithCaptionSets>(projectRequest);
                projectPayload = new ProjectPayload(project);
                captionSetPayload = projectPayload.OriginalCaptionSet.Id == _input.CaptionSetId
                    ? projectPayload.OriginalCaptionSet
                    : projectPayload.CaptionSets.FirstOrDefault(x => x.Id == _input.CaptionSetId);
            }


            return new()
            {
                Result = new()
                {
                    Rendering = new()
                    {
                        Id = response.Id,
                        CaptionSetId = response.CaptionSetId,
                        Stats = response.Status,
                        CreatedAt = response.CreatedAt
                    },
                    Project = projectPayload,
                    CaptionSet = captionSetPayload
                }
            };
        }
        catch (Exception ex)
        {
            if (ex.Message == "Bad Request")
                throw new("Could not find a render, perhaps it has been cancelled");

            throw;
        }
    }
}