using Apps.CaptionHub.Api;
using Apps.CaptionHub.Constants;
using Apps.CaptionHub.Models.Entities;
using Apps.CaptionHub.Models.Request.Webhook;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Webhooks;
using Blackbird.Applications.Sdk.Utils.Extensions.Http;
using RestSharp;

namespace Apps.CaptionHub.Webhooks.Handlers.WebhookHandlers.Base;

public abstract class CaptionHubWebhookHandler : IWebhookEventHandler
{
    private readonly CaptionHubClient _client;

    public CaptionHubWebhookHandler()
    {
        _client = new();
    }

    protected abstract string Event { get; }

    public Task SubscribeAsync(IEnumerable<AuthenticationCredentialsProvider> creds,
        Dictionary<string, string> values)
    {
        var request = new CaptionHubRequest(ApiEndpoints.Webhooks, Method.Post, creds)
            .WithJsonBody(new CreateWebhookRequest(values[CredsNames.WebhookUrlKey], new[] { Event }),
                JsonConfig.Settings);

        return _client.ExecuteWithErrorHandling(request);
    }

    public async Task UnsubscribeAsync(IEnumerable<AuthenticationCredentialsProvider> creds,
        Dictionary<string, string> values)
    {
        var webhooks = await GetAllWebhooks(creds);
        var webhookToDelete = webhooks.FirstOrDefault(x => x.Url == values[CredsNames.WebhookUrlKey]);

        if (webhookToDelete is null)
            return;

        var endpoint = $"{ApiEndpoints.Webhooks}/{webhookToDelete.Id}";
        var request = new CaptionHubRequest(endpoint, Method.Delete, creds);

        await _client.ExecuteWithErrorHandling(request);
    }

    private Task<WebhookEntity[]> GetAllWebhooks(IEnumerable<AuthenticationCredentialsProvider> creds)
    {
        var request = new CaptionHubRequest(ApiEndpoints.Webhooks, Method.Get, creds);

        return _client.ExecuteWithErrorHandling<WebhookEntity[]>(request);
    }
}