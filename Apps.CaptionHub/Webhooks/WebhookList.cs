using Apps.CaptionHub.Webhooks.Handlers;
using Apps.CaptionHub.Webhooks.Models.Payloads.CaptionSet;
using Apps.CaptionHub.Webhooks.Models.Payloads.Project;
using Blackbird.Applications.Sdk.Common.Webhooks;
using Newtonsoft.Json;

namespace Apps.CaptionHub.Webhooks;

[WebhookList]
public class WebhookList
{
    [Webhook("On project status changed (manual)", Description = "On a project status changed (manual)")]
    public Task<WebhookResponse<ProjectPayload>> OnProjectStatusChanged(WebhookRequest webhookRequest)
        => HandleCallback<ProjectPayload>(webhookRequest);
    
    [Webhook("On caption set status changed (manual)", Description = "On a project caption set status changed (manual)")]
    public Task<WebhookResponse<CaptionSetEventPayload>> OnCaptionSetStatusChanged(WebhookRequest webhookRequest)
        => HandleCallback<CaptionSetEventPayload>(webhookRequest);

    [Webhook("On automatic transcription completed", typeof(AutomaticTranscriptionCompleteHandler),
        Description = "On project automatic transcription completed")]
    public Task<WebhookResponse<ProjectPayload>> OnAutomaticTranscriptionCompleted(WebhookRequest webhookRequest)
        => HandleCallback<ProjectPayload>(webhookRequest);
    
    [Webhook("On automatic transcription failed", typeof(AutomaticTranscriptionFailedHandler),
        Description = "On project automatic transcription failed")]
    public Task<WebhookResponse<ProjectPayload>> OnAutomaticTranscriptionFailed(WebhookRequest webhookRequest)
        => HandleCallback<ProjectPayload>(webhookRequest);
    
    [Webhook("On automatic alignment completed", typeof(AutomaticAlignmentCompleteHandler),
        Description = "On project automatic alignment completed")]
    public Task<WebhookResponse<ProjectPayload>> OnAutomaticAlignmentCompleted(WebhookRequest webhookRequest)
        => HandleCallback<ProjectPayload>(webhookRequest);
    
    [Webhook("On project encode state changed", typeof(ProjectEncodeStateChangedHandler),
        Description = "On any project encode state changed")]
    public Task<WebhookResponse<ProjectEncodePayload>> OnProjectEncodeStateChanged(WebhookRequest webhookRequest)
        => HandleCallback<ProjectEncodePayload>(webhookRequest);
    
    [Webhook("On caption set approved", typeof(CaptionSetApprovedHandler),
        Description = "On any project caption set approved")]
    public Task<WebhookResponse<CaptionSetEventPayload>> OnCaptionSetApproved(WebhookRequest webhookRequest)
        => HandleCallback<CaptionSetEventPayload>(webhookRequest);
    
    [Webhook("On caption set unapproved", typeof(CaptionSetUnapprovedHandler),
        Description = "On any project caption set unapproved")]
    public Task<WebhookResponse<CaptionSetEventPayload>> OnCaptionSetUnapproved(WebhookRequest webhookRequest)
        => HandleCallback<CaptionSetEventPayload>(webhookRequest);

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