using Apps.CaptionHub.Webhooks.Handlers.CallbackHandlers;
using Apps.CaptionHub.Webhooks.Models.Payloads.CaptionSet.Callbacks;
using Apps.CaptionHub.Webhooks.Models.Payloads.Project.Callbacks;
using Blackbird.Applications.Sdk.Common.Webhooks;
using Newtonsoft.Json;

namespace Apps.CaptionHub.Webhooks;

[WebhookList]
public class CallbackList
{
    [Webhook("On project status changed (manual)", Description = "On a project status changed (manual)")]
    public Task<WebhookResponse<ProjectCallbackPayload>> OnProjectStatusChanged(WebhookRequest webhookRequest)
        => HandleCallback<ProjectCallbackPayload>(webhookRequest);
    
    [Webhook("On caption set status changed (manual)", Description = "On a project caption set status changed (manual)")]
    public Task<WebhookResponse<CaptionSetCallbackResponse>> OnCaptionSetStatusChanged(WebhookRequest webhookRequest)
        => HandleCallback<CaptionSetCallbackResponse>(webhookRequest);

    [Webhook("On automatic transcription completed", typeof(AutomaticTranscriptionCompleteHandler),
        Description = "On project automatic transcription completed")]
    public Task<WebhookResponse<ProjectCallbackPayload>> OnAutomaticTranscriptionCompleted(WebhookRequest webhookRequest)
        => HandleCallback<ProjectCallbackPayload>(webhookRequest);
    
    [Webhook("On automatic transcription failed", typeof(AutomaticTranscriptionFailedHandler),
        Description = "On project automatic transcription failed")]
    public Task<WebhookResponse<ProjectCallbackPayload>> OnAutomaticTranscriptionFailed(WebhookRequest webhookRequest)
        => HandleCallback<ProjectCallbackPayload>(webhookRequest);
    
    [Webhook("On automatic alignment completed", typeof(AutomaticAlignmentCompleteHandler),
        Description = "On project automatic alignment completed")]
    public Task<WebhookResponse<ProjectCallbackPayload>> OnAutomaticAlignmentCompleted(WebhookRequest webhookRequest)
        => HandleCallback<ProjectCallbackPayload>(webhookRequest);
    
    [Webhook("On project encode state changed", typeof(ProjectEncodeStateChangedHandler),
        Description = "On any project encode state changed")]
    public Task<WebhookResponse<ProjectEncodeCallbackPayload>> OnProjectEncodeStateChanged(WebhookRequest webhookRequest)
        => HandleCallback<ProjectEncodeCallbackPayload>(webhookRequest);
    
    [Webhook("On caption set approved", typeof(CaptionSetApprovedHandler),
        Description = "On any project caption set approved")]
    public Task<WebhookResponse<CaptionSetCallbackResponse>> OnCaptionSetApproved(WebhookRequest webhookRequest)
        => HandleCallback<CaptionSetCallbackResponse>(webhookRequest);
    
    [Webhook("On caption set unapproved", typeof(CaptionSetUnapprovedHandler),
        Description = "On any project caption set unapproved")]
    public Task<WebhookResponse<CaptionSetCallbackResponse>> OnCaptionSetUnapproved(WebhookRequest webhookRequest)
        => HandleCallback<CaptionSetCallbackResponse>(webhookRequest);

    private Task<WebhookResponse<T>> HandleCallback<T>(WebhookRequest webhookRequest) where T : class
    {
        var payload = webhookRequest.Body.ToString();
        ArgumentException.ThrowIfNullOrEmpty(payload, nameof(webhookRequest.Body));

        var result = JsonConvert.DeserializeObject<T>(payload);

        return Task.FromResult(new WebhookResponse<T>
        {
            HttpResponseMessage = null,
            Result = result
        });
    }
}