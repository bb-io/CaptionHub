using System.Net;
using Apps.CaptionHub.Webhooks.Handlers.CallbackHandlers;
using Apps.CaptionHub.Webhooks.Models.Inputs;
using Apps.CaptionHub.Webhooks.Models.Payloads.CaptionSet.Callbacks;
using Apps.CaptionHub.Webhooks.Models.Payloads.Project.Callbacks;
using Blackbird.Applications.Sdk.Common.Webhooks;
using Newtonsoft.Json;

namespace Apps.CaptionHub.Webhooks;

[WebhookList]
public class CallbackList
{
    [Webhook("On project status changed (manual)", Description = "On a project status changed (manual)")]
    public Task<WebhookResponse<ProjectCallbackPayload>> OnProjectStatusChanged(WebhookRequest webhookRequest,
        [WebhookParameter] ProjectWebhookInput project)
    {
        var payload = GetPayload<ProjectCallbackPayload>(webhookRequest);

        if (project.ProjectId != null && payload.ProjectId != project.ProjectId)
            return Task.FromResult(GetPreflightResponse<ProjectCallbackPayload>());

        return Task.FromResult(new WebhookResponse<ProjectCallbackPayload>()
        {
            Result = payload
        });
    }

    [Webhook("On caption set status changed (manual)",
        Description = "On a project caption set status changed (manual)")]
    public Task<WebhookResponse<CaptionSetCallbackResponse>> OnCaptionSetStatusChanged(WebhookRequest webhookRequest, [WebhookParameter] CaptionSetWebhookInput input)
    {
        var payload = GetPayload<CaptionSetCallbackResponse>(webhookRequest);

        if (input.ProjectId != null && payload.Project.Id != input.ProjectId)
            return Task.FromResult(GetPreflightResponse<CaptionSetCallbackResponse>());
        
        if (input.CaptionSetId != null && payload.CaptionSet.CaptionSetId != input.CaptionSetId)
            return Task.FromResult(GetPreflightResponse<CaptionSetCallbackResponse>());

        return Task.FromResult(new WebhookResponse<CaptionSetCallbackResponse>()
        {
            Result = payload
        });
    }

    [Webhook("On automatic transcription completed", typeof(AutomaticTranscriptionCompleteHandler),
        Description = "On project automatic transcription completed")]
    public Task<WebhookResponse<ProjectCallbackPayload>> OnAutomaticTranscriptionCompleted(
        WebhookRequest webhookRequest,
        [WebhookParameter] ProjectWebhookInput project)
    {
        var payload = GetPayload<ProjectCallbackPayload>(webhookRequest);

        if (project.ProjectId != null && payload.ProjectId != project.ProjectId)
            return Task.FromResult(GetPreflightResponse<ProjectCallbackPayload>());

        return Task.FromResult(new WebhookResponse<ProjectCallbackPayload>()
        {
            Result = payload
        });
    }

    [Webhook("On automatic transcription failed", typeof(AutomaticTranscriptionFailedHandler),
        Description = "On project automatic transcription failed")]
    public Task<WebhookResponse<ProjectCallbackPayload>> OnAutomaticTranscriptionFailed(WebhookRequest webhookRequest,
        [WebhookParameter] ProjectWebhookInput project)
    {
        var payload = GetPayload<ProjectCallbackPayload>(webhookRequest);

        if (project.ProjectId != null && payload.ProjectId != project.ProjectId)
            return Task.FromResult(GetPreflightResponse<ProjectCallbackPayload>());

        return Task.FromResult(new WebhookResponse<ProjectCallbackPayload>()
        {
            Result = payload
        });
    }

    [Webhook("On automatic alignment completed", typeof(AutomaticAlignmentCompleteHandler),
        Description = "On project automatic alignment completed")]
    public Task<WebhookResponse<ProjectCallbackPayload>> OnAutomaticAlignmentCompleted(WebhookRequest webhookRequest,
        [WebhookParameter] ProjectWebhookInput project)
    {
        var payload = GetPayload<ProjectCallbackPayload>(webhookRequest);

        if (project.ProjectId != null && payload.ProjectId != project.ProjectId)
            return Task.FromResult(GetPreflightResponse<ProjectCallbackPayload>());

        return Task.FromResult(new WebhookResponse<ProjectCallbackPayload>()
        {
            Result = payload
        });
    }

    [Webhook("On project encode state changed", typeof(ProjectEncodeStateChangedHandler),
        Description = "On any project encode state changed")]
    public Task<WebhookResponse<ProjectEncodeCallbackPayload>> OnProjectEncodeStateChanged(
        WebhookRequest webhookRequest,
        [WebhookParameter] ProjectWebhookInput project)
    {
        var payload = GetPayload<ProjectEncodeCallbackPayload>(webhookRequest);

        if (project.ProjectId != null && payload.ProjectId != project.ProjectId)
            return Task.FromResult(GetPreflightResponse<ProjectEncodeCallbackPayload>());

        return Task.FromResult(new WebhookResponse<ProjectEncodeCallbackPayload>()
        {
            Result = payload
        });
    }

    [Webhook("On caption set approved", typeof(CaptionSetApprovedHandler),
        Description = "On any project caption set approved")]
    public Task<WebhookResponse<CaptionSetCallbackResponse>> OnCaptionSetApproved(WebhookRequest webhookRequest, [WebhookParameter] CaptionSetApprovedWebhookInput input)
    {
        var root = GetPayload<RootCaptionHubPayload>(webhookRequest);
        var payload = root.Data;

        if (input.ProjectId != null && payload.Project.Id != input.ProjectId)
            return Task.FromResult(GetPreflightResponse<CaptionSetCallbackResponse>());

        if (input.CaptionSetId != null && payload.CaptionSet.CaptionSetId != input.CaptionSetId)
            return Task.FromResult(GetPreflightResponse<CaptionSetCallbackResponse>());

        if (input.LanguageCodes != null && input.LanguageCodes.Any())
        {
            if (!input.LanguageCodes.Contains(payload.CaptionSet.Language.Code))
                return Task.FromResult(GetPreflightResponse<CaptionSetCallbackResponse>());
        }

        return Task.FromResult(new WebhookResponse<CaptionSetCallbackResponse>()
        {
            Result = payload
        });
    }

    [Webhook("On caption set unapproved", typeof(CaptionSetUnapprovedHandler),
        Description = "On any project caption set unapproved")]
    public Task<WebhookResponse<CaptionSetCallbackResponse>> OnCaptionSetUnapproved(WebhookRequest webhookRequest, [WebhookParameter] CaptionSetWebhookInput input)
    {
        var payload = GetPayload<CaptionSetCallbackResponse>(webhookRequest);

        if (input.ProjectId != null && payload.Project.Id != input.ProjectId)
            return Task.FromResult(GetPreflightResponse<CaptionSetCallbackResponse>());
        
        if (input.CaptionSetId != null && payload.CaptionSet.CaptionSetId != input.CaptionSetId)
            return Task.FromResult(GetPreflightResponse<CaptionSetCallbackResponse>());

        return Task.FromResult(new WebhookResponse<CaptionSetCallbackResponse>()
        {
            Result = payload
        });
    }

    private T GetPayload<T>(WebhookRequest webhookRequest) where T : class
    {
        var payload = webhookRequest.Body.ToString();
        ArgumentException.ThrowIfNullOrEmpty(payload, nameof(webhookRequest.Body));

        return JsonConvert.DeserializeObject<T>(payload)!;
    }

    private WebhookResponse<T> GetPreflightResponse<T>() where T : class => new()
    {
        HttpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK),
        ReceivedWebhookRequestType = WebhookRequestType.Preflight
    };
}