namespace Apps.CaptionHub.Models.Request.Webhook;

public record CreateWebhookRequest(string Url, IEnumerable<string> SubscribedEvents);