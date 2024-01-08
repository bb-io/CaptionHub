namespace Apps.CaptionHub.Webhooks.Models.Payloads;

public class CaptionHubWebhookPayload<T>
{
    public T Data { get; set; }
}