using System.Net;
using Apps.CaptionHub.Constants;
using Apps.CaptionHub.Webhooks.Handlers.WebhookHandlers.CaptionSet;
using Apps.CaptionHub.Webhooks.Handlers.WebhookHandlers.Project;
using Apps.CaptionHub.Webhooks.Models.Inputs;
using Apps.CaptionHub.Webhooks.Models.Payloads;
using Apps.CaptionHub.Webhooks.Models.Responses;
using Blackbird.Applications.Sdk.Common.Webhooks;
using Newtonsoft.Json;

namespace Apps.CaptionHub.Webhooks;

[WebhookList]
public class WebhookList
{
    #region Caption set

    [Webhook("On caption set created", typeof(CaptionSetCreatedHandler),
        Description = "On any project caption set created")]
    public Task<WebhookResponse<CaptionSetWebhookResponse>> OnCaptionSetCreated(WebhookRequest webhookRequest,
        [WebhookParameter] CaptionSetWebhookInput input)
    {
        var payload = GetPayload<CaptionSetWebhookResponse>(webhookRequest);

        if (input.ProjectId != null && payload.Project.Id != input.ProjectId)
            return Task.FromResult(GetPreflightResponse<CaptionSetWebhookResponse>());

        if (input.CaptionSetId != null && payload.CaptionSet.Id != input.CaptionSetId)
            return Task.FromResult(GetPreflightResponse<CaptionSetWebhookResponse>());

        return Task.FromResult(new WebhookResponse<CaptionSetWebhookResponse>()
        {
            Result = payload
        });
    }

    [Webhook("On caption set deleted", typeof(CaptionSetDeletedHandler),
        Description = "On any project caption set deleted")]
    public Task<WebhookResponse<CaptionSetWebhookResponse>> OnCaptionSetDeleted(WebhookRequest webhookRequest,
        [WebhookParameter] CaptionSetWebhookInput input)
    {
        var payload = GetPayload<CaptionSetWebhookResponse>(webhookRequest);

        if (input.ProjectId != null && payload.Project.Id != input.ProjectId)
            return Task.FromResult(GetPreflightResponse<CaptionSetWebhookResponse>());

        if (input.CaptionSetId != null && payload.CaptionSet.Id != input.CaptionSetId)
            return Task.FromResult(GetPreflightResponse<CaptionSetWebhookResponse>());

        return Task.FromResult(new WebhookResponse<CaptionSetWebhookResponse>()
        {
            Result = payload
        });
    }

    [Webhook("On caption set published", typeof(CaptionSetPublishedHandler),
        Description = "On any project caption set published")]
    public Task<WebhookResponse<CaptionSetWebhookResponse>> OnCaptionSetPublished(WebhookRequest webhookRequest,
        [WebhookParameter] CaptionSetWebhookInput input)
    {
        var payload = GetPayload<CaptionSetWebhookResponse>(webhookRequest);

        if (input.ProjectId != null && payload.Project.Id != input.ProjectId)
            return Task.FromResult(GetPreflightResponse<CaptionSetWebhookResponse>());

        if (input.CaptionSetId != null && payload.CaptionSet.Id != input.CaptionSetId)
            return Task.FromResult(GetPreflightResponse<CaptionSetWebhookResponse>());

        return Task.FromResult(new WebhookResponse<CaptionSetWebhookResponse>()
        {
            Result = payload
        });
    }

    [Webhook("On caption set publish failed", typeof(CaptionSetPublishFailedHandler),
        Description = "On any project caption set publish failed")]
    public Task<WebhookResponse<CaptionSetWebhookResponse>> OnCaptionSetPublishFailed(WebhookRequest webhookRequest,
        [WebhookParameter] CaptionSetWebhookInput input)
    {
        var payload = GetPayload<CaptionSetWebhookResponse>(webhookRequest);

        if (input.ProjectId != null && payload.Project.Id != input.ProjectId)
            return Task.FromResult(GetPreflightResponse<CaptionSetWebhookResponse>());

        if (input.CaptionSetId != null && payload.CaptionSet.Id != input.CaptionSetId)
            return Task.FromResult(GetPreflightResponse<CaptionSetWebhookResponse>());

        return Task.FromResult(new WebhookResponse<CaptionSetWebhookResponse>()
        {
            Result = payload
        });
    }

    [Webhook("On caption set rendered", typeof(CaptionSetRenderedHandler),
        Description = "On any project caption set publish rendered")]
    public Task<WebhookResponse<RenderingWebhookResponse>> OnCaptionSetRendered(WebhookRequest webhookRequest,
        [WebhookParameter] RenderWebhookInput input)
    {
        var payload = GetPayload<RenderingWebhookResponse>(webhookRequest);

        if (input.ProjectId != null && payload.Project.Id != input.ProjectId)
            return Task.FromResult(GetPreflightResponse<RenderingWebhookResponse>());

        if (input.CaptionSetId != null && payload.Rendering.CaptionSetId != input.CaptionSetId)
            return Task.FromResult(GetPreflightResponse<RenderingWebhookResponse>());

        if (input.RenderId != null && payload.Rendering.Id != input.RenderId)
            return Task.FromResult(GetPreflightResponse<RenderingWebhookResponse>());

        return Task.FromResult(new WebhookResponse<RenderingWebhookResponse>()
        {
            Result = payload
        });
    }

    [Webhook("On caption set transcribed", typeof(CaptionSetTranscribedHandler),
        Description = "On any project caption set transcribed")]
    public Task<WebhookResponse<CaptionSetWebhookResponse>> OnCaptionSetTranscribed(WebhookRequest webhookRequest,
        [WebhookParameter] CaptionSetWebhookInput input)
    {
        var payload = GetPayload<CaptionSetWebhookResponse>(webhookRequest);

        if (input.ProjectId != null && payload.Project.Id != input.ProjectId)
            return Task.FromResult(GetPreflightResponse<CaptionSetWebhookResponse>());

        if (input.CaptionSetId != null && payload.CaptionSet.Id != input.CaptionSetId)
            return Task.FromResult(GetPreflightResponse<CaptionSetWebhookResponse>());

        return Task.FromResult(new WebhookResponse<CaptionSetWebhookResponse>()
        {
            Result = payload
        });
    }

    [Webhook("On caption set transcription failed", typeof(CaptionSetTranscriptionFailedHandler),
        Description = "On any project caption set transcription failed")]
    public Task<WebhookResponse<CaptionSetWebhookResponse>> OnCaptionSetTranscriptionFailed(
        WebhookRequest webhookRequest,
        [WebhookParameter] CaptionSetWebhookInput input)
    {
        var payload = GetPayload<CaptionSetWebhookResponse>(webhookRequest);

        if (input.ProjectId != null && payload.Project.Id != input.ProjectId)
            return Task.FromResult(GetPreflightResponse<CaptionSetWebhookResponse>());

        if (input.CaptionSetId != null && payload.CaptionSet.Id != input.CaptionSetId)
            return Task.FromResult(GetPreflightResponse<CaptionSetWebhookResponse>());

        return Task.FromResult(new WebhookResponse<CaptionSetWebhookResponse>()
        {
            Result = payload
        });
    }

    [Webhook("On caption set translated", typeof(CaptionSetTranslatedHandler),
        Description = "On any project caption set translated")]
    public Task<WebhookResponse<CaptionSetWebhookResponse>> OnCaptionSetTranslated(WebhookRequest webhookRequest,
        [WebhookParameter] CaptionSetWebhookInput input)
    {
        var payload = GetPayload<CaptionSetWebhookResponse>(webhookRequest);

        if (input.ProjectId != null && payload.Project.Id != input.ProjectId)
            return Task.FromResult(GetPreflightResponse<CaptionSetWebhookResponse>());

        if (input.CaptionSetId != null && payload.CaptionSet.Id != input.CaptionSetId)
            return Task.FromResult(GetPreflightResponse<CaptionSetWebhookResponse>());

        return Task.FromResult(new WebhookResponse<CaptionSetWebhookResponse>()
        {
            Result = payload
        });
    }

    [Webhook("On caption set translations failed", typeof(CaptionSetTranslationsFailedHandler),
        Description = "On any project caption set translations failed")]
    public Task<WebhookResponse<CaptionSetWebhookResponse>> OnCaptionSetTranslationsFailed(
        WebhookRequest webhookRequest,
        [WebhookParameter] CaptionSetWebhookInput input)
    {
        var payload = GetPayload<CaptionSetWebhookResponse>(webhookRequest);

        if (input.ProjectId != null && payload.Project.Id != input.ProjectId)
            return Task.FromResult(GetPreflightResponse<CaptionSetWebhookResponse>());

        if (input.CaptionSetId != null && payload.CaptionSet.Id != input.CaptionSetId)
            return Task.FromResult(GetPreflightResponse<CaptionSetWebhookResponse>());

        return Task.FromResult(new WebhookResponse<CaptionSetWebhookResponse>()
        {
            Result = payload
        });
    }

    [Webhook("On caption set updated", typeof(CaptionSetUpdatedHandler),
        Description = "On any project caption set updated")]
    public Task<WebhookResponse<CaptionSetWebhookResponse>> OnCaptionSetUpdated(WebhookRequest webhookRequest,
        [WebhookParameter] CaptionSetWebhookInput input)
    {
        var payload = GetPayload<CaptionSetWebhookResponse>(webhookRequest);

        if (input.ProjectId != null && payload.Project.Id != input.ProjectId)
            return Task.FromResult(GetPreflightResponse<CaptionSetWebhookResponse>());

        if (input.CaptionSetId != null && payload.CaptionSet.Id != input.CaptionSetId)
            return Task.FromResult(GetPreflightResponse<CaptionSetWebhookResponse>());

        return Task.FromResult(new WebhookResponse<CaptionSetWebhookResponse>()
        {
            Result = payload
        });
    }

    #endregion

    #region Project

    [Webhook("On project archived", typeof(ProjectArchivedHandler),
        Description = "On any project archived")]
    public Task<WebhookResponse<ProjectWebhookResponse>> OnProjectArchived(WebhookRequest webhookRequest,
        [WebhookParameter] ProjectWebhookInput project)
    {
        var payload = GetPayload<ProjectWebhookResponse>(webhookRequest);

        if (project.ProjectId != null && payload.Project.Id != project.ProjectId)
            return Task.FromResult(GetPreflightResponse<ProjectWebhookResponse>());

        return Task.FromResult(new WebhookResponse<ProjectWebhookResponse>()
        {
            Result = payload
        });
    }

    [Webhook("On project created", typeof(ProjectCreatedHandler),
        Description = "On any project created")]
    public Task<WebhookResponse<ProjectWebhookResponse>> OnProjectCreated(WebhookRequest webhookRequest)
    {
        var payload = GetPayload<ProjectWebhookResponse>(webhookRequest);

        return Task.FromResult(new WebhookResponse<ProjectWebhookResponse>()
        {
            Result = payload
        });
    }

    [Webhook("On project deleted", typeof(ProjectDeletedHandler),
        Description = "On any project deleted")]
    public Task<WebhookResponse<ProjectWebhookResponse>> OnProjectDeleted(WebhookRequest webhookRequest,
        [WebhookParameter] ProjectWebhookInput project)
    {
        var payload = GetPayload<ProjectWebhookResponse>(webhookRequest);

        if (project.ProjectId != null && payload.Project.Id != project.ProjectId)
            return Task.FromResult(GetPreflightResponse<ProjectWebhookResponse>());

        return Task.FromResult(new WebhookResponse<ProjectWebhookResponse>()
        {
            Result = payload
        });
    }

    [Webhook("On project encode completed", typeof(ProjectEncodeCompletedHandler),
        Description = "On any project encode completed")]
    public Task<WebhookResponse<ProjectWebhookResponse>> OnProjectEncodeCompleted(WebhookRequest webhookRequest,
        [WebhookParameter] ProjectWebhookInput project)
    {
        var payload = GetPayload<ProjectWebhookResponse>(webhookRequest);

        if (project.ProjectId != null && payload.Project.Id != project.ProjectId)
            return Task.FromResult(GetPreflightResponse<ProjectWebhookResponse>());

        return Task.FromResult(new WebhookResponse<ProjectWebhookResponse>()
        {
            Result = payload
        });
    }

    [Webhook("On project encode failed", typeof(ProjectEncodeFailedHandler),
        Description = "On any project encode failed")]
    public Task<WebhookResponse<ProjectWebhookResponse>> OnProjectEncodeFailed(WebhookRequest webhookRequest,
        [WebhookParameter] ProjectWebhookInput project)
    {
        var payload = GetPayload<ProjectWebhookResponse>(webhookRequest);

        if (project.ProjectId != null && payload.Project.Id != project.ProjectId)
            return Task.FromResult(GetPreflightResponse<ProjectWebhookResponse>());

        return Task.FromResult(new WebhookResponse<ProjectWebhookResponse>()
        {
            Result = payload
        });
    }

    [Webhook("On project metadata updated", typeof(ProjectMetadataUpdatedHandler),
        Description = "On any project metadata updated")]
    public Task<WebhookResponse<ProjectWebhookResponse>> OnProjectMetadataUpdated(WebhookRequest webhookRequest,
        [WebhookParameter] ProjectWebhookInput project)
    {
        var payload = GetPayload<ProjectWebhookResponse>(webhookRequest);

        if (project.ProjectId != null && payload.Project.Id != project.ProjectId)
            return Task.FromResult(GetPreflightResponse<ProjectWebhookResponse>());

        return Task.FromResult(new WebhookResponse<ProjectWebhookResponse>()
        {
            Result = payload
        });
    }

    [Webhook("On project unarchived", typeof(ProjectUnarchivedHandler),
        Description = "On any project unarchived")]
    public Task<WebhookResponse<ProjectWebhookResponse>> OnProjectUnarchived(WebhookRequest webhookRequest,
        [WebhookParameter] ProjectWebhookInput project)
    {
        var payload = GetPayload<ProjectWebhookResponse>(webhookRequest);

        if (project.ProjectId != null && payload.Project.Id != project.ProjectId)
            return Task.FromResult(GetPreflightResponse<ProjectWebhookResponse>());

        return Task.FromResult(new WebhookResponse<ProjectWebhookResponse>()
        {
            Result = payload
        });
    }

    [Webhook("On project video replaced", typeof(ProjectVideoReplacedHandler),
        Description = "On any project video replaced")]
    public Task<WebhookResponse<ProjectWebhookResponse>> OnProjectVideoReplaced(WebhookRequest webhookRequest,
        [WebhookParameter] ProjectWebhookInput project)
    {
        var payload = GetPayload<ProjectWebhookResponse>(webhookRequest);

        if (project.ProjectId != null && payload.Project.Id != project.ProjectId)
            return Task.FromResult(GetPreflightResponse<ProjectWebhookResponse>());

        return Task.FromResult(new WebhookResponse<ProjectWebhookResponse>()
        {
            Result = payload
        });
    }

    #endregion

    private T GetPayload<T>(WebhookRequest webhookRequest) where T : class
    {
        var payload = webhookRequest.Body.ToString();
        ArgumentException.ThrowIfNullOrEmpty(payload, nameof(webhookRequest.Body));

        var result = JsonConvert.DeserializeObject<CaptionHubWebhookPayload<T>>(payload, JsonConfig.Settings)!;
        return result.Data;
    }

    private WebhookResponse<T> GetPreflightResponse<T>() where T : class => new()
    {
        HttpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK),
        ReceivedWebhookRequestType = WebhookRequestType.Preflight
    };
}