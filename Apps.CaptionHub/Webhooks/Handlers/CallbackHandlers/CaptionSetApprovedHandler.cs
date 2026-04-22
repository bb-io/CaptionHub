using Apps.CaptionHub.Api;
using Apps.CaptionHub.Constants;
using Apps.CaptionHub.Models.Entities;
using Apps.CaptionHub.Webhooks.Bridge.Base;
using Apps.CaptionHub.Webhooks.Models.Inputs;
using Apps.CaptionHub.Webhooks.Models.Payloads.CaptionSet.Callbacks;
using Apps.CaptionHub.Webhooks.Models.Payloads.Language;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Common.Webhooks;
using RestSharp;

namespace Apps.CaptionHub.Webhooks.Handlers.CallbackHandlers;

public class CaptionSetApprovedHandler : BaseWebhookBridgeHandler,
    IAfterSubscriptionWebhookEventHandler<CaptionSetCallbackResponse>
{
    public static string Event => "caption_set.workflow.approved";
    private readonly CaptionSetApprovedWebhookInput _input;

    public CaptionSetApprovedHandler(InvocationContext invocationContext, [WebhookParameter] CaptionSetApprovedWebhookInput input) : base(invocationContext, Event, input.ProjectId)
    {
        _input = input;
    }

    public async Task<AfterSubscriptionEventResponse<CaptionSetCallbackResponse>> OnWebhookSubscribedAsync()
    {
        if (string.IsNullOrWhiteSpace(_input.ProjectId))
            return null!;

        var projectEndpoint = $"{ApiEndpoints.Projects}/{_input.ProjectId}";
        var projectRequest = new CaptionHubRequest(projectEndpoint, Method.Get, InvocationContext.AuthenticationCredentialsProviders);

        var project = await Client.ExecuteWithErrorHandling<ProjectEntityWithCaptionSets>(projectRequest);
        var captionSet = GetMatchingCaptionSets(project).FirstOrDefault(IsApproved);

        if (captionSet is null)
            return null!;

        return new()
        {
            Result = new()
            {
                Project = new()
                {
                    Id = project.Id,
                    ProjectName = project.Name
                },
                CaptionSet = new()
                {
                    CaptionSetId = captionSet.Id,
                    Language = new LanguageCallbackPayload
                    {
                        LanguageName = captionSet.Language.Name,
                        Code = captionSet.Language.CodeAndTerritory
                    }
                }
            }
        };
    }

    private IEnumerable<CaptionSetEntity> GetMatchingCaptionSets(ProjectEntityWithCaptionSets project)
    {
        var captionSets = project.CaptionSets.AsEnumerable();

        if (project.OriginalCaptionSet is not null)
            captionSets = captionSets.Prepend(project.OriginalCaptionSet);

        if (!string.IsNullOrWhiteSpace(_input.CaptionSetId))
            captionSets = captionSets.Where(x => x.Id == _input.CaptionSetId);

        if (_input.LanguageCodes?.Any() == true)
            captionSets = captionSets.Where(x => _input.LanguageCodes.Contains(x.Language.CodeAndTerritory));

        return captionSets;
    }

    private static bool IsApproved(CaptionSetEntity captionSet)
    {
        return captionSet.Segments?.Any() == true
            && captionSet.Segments.All(x => x.WorkflowState == "approved");
    }
}
