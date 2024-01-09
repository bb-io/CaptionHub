using Apps.CaptionHub.Constants;
using Apps.CaptionHub.Webhooks.Handlers.WebhookHandlers.CaptionSet;
using Apps.CaptionHub.Webhooks.Handlers.WebhookHandlers.Project;
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
    public Task<WebhookResponse<CaptionSetWebhookResponse>> OnCaptionSetCreated(WebhookRequest webhookRequest)
        => HandleWebhook<CaptionSetWebhookResponse>(webhookRequest);

    [Webhook("On caption set deleted", typeof(CaptionSetDeletedHandler),
        Description = "On any project caption set deleted")]
    public Task<WebhookResponse<CaptionSetWebhookResponse>> OnCaptionSetDeleted(WebhookRequest webhookRequest)
        => HandleWebhook<CaptionSetWebhookResponse>(webhookRequest);

    [Webhook("On caption set published", typeof(CaptionSetPublishedHandler),
        Description = "On any project caption set published")]
    public Task<WebhookResponse<CaptionSetWebhookResponse>> OnCaptionSetPublished(WebhookRequest webhookRequest)
        => HandleWebhook<CaptionSetWebhookResponse>(webhookRequest);

    [Webhook("On caption set publish failed", typeof(CaptionSetPublishFailedHandler),
        Description = "On any project caption set publish failed")]
    public Task<WebhookResponse<CaptionSetWebhookResponse>> OnCaptionSetPublishFailed(WebhookRequest webhookRequest)
        => HandleWebhook<CaptionSetWebhookResponse>(webhookRequest);

    [Webhook("On caption set rendered", typeof(CaptionSetRenderedHandler),
        Description = "On any project caption set publish rendered")]
    public Task<WebhookResponse<RenderingWebhookResponse>> OnCaptionSetRendered(WebhookRequest webhookRequest)
        => HandleWebhook<RenderingWebhookResponse>(webhookRequest);

    [Webhook("On caption set transcribed", typeof(CaptionSetTranscribedHandler),
        Description = "On any project caption set transcribed")]
    public Task<WebhookResponse<CaptionSetWebhookResponse>> OnCaptionSetTranscribed(WebhookRequest webhookRequest)
        => HandleWebhook<CaptionSetWebhookResponse>(webhookRequest);

    [Webhook("On caption set transcription failed", typeof(CaptionSetTranscriptionFailedHandler),
        Description = "On any project caption set transcription failed")]
    public Task<WebhookResponse<CaptionSetWebhookResponse>> OnCaptionSetTranscriptionFailed(
        WebhookRequest webhookRequest)
        => HandleWebhook<CaptionSetWebhookResponse>(webhookRequest);

    [Webhook("On caption set translated", typeof(CaptionSetTranslatedHandler),
        Description = "On any project caption set translated")]
    public Task<WebhookResponse<CaptionSetWebhookResponse>> OnCaptionSetTranslated(WebhookRequest webhookRequest)
        => HandleWebhook<CaptionSetWebhookResponse>(webhookRequest);

    [Webhook("On caption set translations failed", typeof(CaptionSetTranslationsFailedHandler),
        Description = "On any project caption set translations failed")]
    public Task<WebhookResponse<CaptionSetWebhookResponse>> OnCaptionSetTranslationsFailed(
        WebhookRequest webhookRequest)
        => HandleWebhook<CaptionSetWebhookResponse>(webhookRequest);

    [Webhook("On caption set updated", typeof(CaptionSetUpdatedHandler),
        Description = "On any project caption set updated")]
    public Task<WebhookResponse<CaptionSetWebhookResponse>> OnCaptionSetUpdated(WebhookRequest webhookRequest)
        => HandleWebhook<CaptionSetWebhookResponse>(webhookRequest);

    #endregion

    #region Project

    [Webhook("On project archived", typeof(ProjectArchivedHandler),
        Description = "On any project archived")]
    public Task<WebhookResponse<ProjectWebhookResponse>> OnProjectArchived(WebhookRequest webhookRequest)
        => HandleWebhook<ProjectWebhookResponse>(webhookRequest);

    [Webhook("On project created", typeof(ProjectCreatedHandler),
        Description = "On any project created")]
    public Task<WebhookResponse<ProjectWebhookResponse>> OnProjectCreated(WebhookRequest webhookRequest)
        => HandleWebhook<ProjectWebhookResponse>(webhookRequest);

    [Webhook("On project deleted", typeof(ProjectDeletedHandler),
        Description = "On any project deleted")]
    public Task<WebhookResponse<ProjectWebhookResponse>> OnProjectDeleted(WebhookRequest webhookRequest)
        => HandleWebhook<ProjectWebhookResponse>(webhookRequest);

    [Webhook("On project encode completed", typeof(ProjectEncodeCompletedHandler),
        Description = "On any project encode completed")]
    public Task<WebhookResponse<ProjectWebhookResponse>> OnProjectEncodeCompleted(WebhookRequest webhookRequest)
        => HandleWebhook<ProjectWebhookResponse>(webhookRequest);

    [Webhook("On project encode failed", typeof(ProjectEncodeFailedHandler),
        Description = "On any project encode failed")]
    public Task<WebhookResponse<ProjectWebhookResponse>> OnProjectEncodeFailed(WebhookRequest webhookRequest)
        => HandleWebhook<ProjectWebhookResponse>(webhookRequest);

    [Webhook("On project metadata updated", typeof(ProjectMetadataUpdatedHandler),
        Description = "On any project metadata updated")]
    public Task<WebhookResponse<ProjectWebhookResponse>> OnProjectMetadataUpdated(WebhookRequest webhookRequest)
        => HandleWebhook<ProjectWebhookResponse>(webhookRequest);

    [Webhook("On project unarchived", typeof(ProjectUnarchivedHandler),
        Description = "On any project unarchived")]
    public Task<WebhookResponse<ProjectWebhookResponse>> OnProjectUnarchived(WebhookRequest webhookRequest)
        => HandleWebhook<ProjectWebhookResponse>(webhookRequest);

    [Webhook("On project video replaced", typeof(ProjectUnarchivedHandler),
        Description = "On any project video replaced")]
    public Task<WebhookResponse<ProjectWebhookResponse>> OnProjectVideoReplaced(WebhookRequest webhookRequest)
        => HandleWebhook<ProjectWebhookResponse>(webhookRequest);

    #endregion

    private Task<WebhookResponse<T>> HandleWebhook<T>(WebhookRequest webhookRequest) where T : class
    {
        var payload = webhookRequest.Body.ToString();
        ArgumentException.ThrowIfNullOrEmpty(payload, nameof(webhookRequest.Body));

        var result = JsonConvert.DeserializeObject<CaptionHubWebhookPayload<T>>(payload, JsonConfig.Settings)!;

        return Task.FromResult(new WebhookResponse<T>
        {
            HttpResponseMessage = null,
            Result = result.Data
        });
    }
}