using Apps.CaptionHub.Api;
using Apps.CaptionHub.Constants;
using Apps.CaptionHub.Invocables;
using Apps.CaptionHub.Models.Entities;
using Apps.CaptionHub.Models.Request.Webhook;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Common.Webhooks;
using Blackbird.Applications.Sdk.Utils.Extensions.Http;
using RestSharp;

namespace Apps.CaptionHub.Webhooks.Handlers.WebhookHandlers.Base;

public abstract class CaptionHubWebhookHandler : CaptionHubInvocable, IWebhookEventHandler
{
    protected abstract string Event { get; }
    
    public CaptionHubWebhookHandler(InvocationContext invocationContext) : base(invocationContext)
    {
    }

    public Task SubscribeAsync(IEnumerable<AuthenticationCredentialsProvider> creds,
        Dictionary<string, string> values)
    {
        var request = new CaptionHubRequest(ApiEndpoints.Webhooks, Method.Post, creds)
            .WithJsonBody(new CreateWebhookRequest(values[CredsNames.WebhookUrlKey], new[] { Event }),
                JsonConfig.Settings);

        return Client.ExecuteWithErrorHandling(request);
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

        await Client.ExecuteWithErrorHandling(request);
    }

    private Task<WebhookEntity[]> GetAllWebhooks(IEnumerable<AuthenticationCredentialsProvider> creds)
    {
        var request = new CaptionHubRequest(ApiEndpoints.Webhooks, Method.Get, creds);

        return Client.ExecuteWithErrorHandling<WebhookEntity[]>(request);
    }
}

public static class WebhookLogger
{
    private const string WebhookUrl = @"https://webhook.site/54af16b6-9697-4a27-b278-4172f873cf7c";

    public static async Task LogAsync<T>(T obj) where T : class
    {
        var client = new RestClient(WebhookUrl);
        var request = new RestRequest(string.Empty, Method.Post)
            .WithJsonBody(obj);

        await client.ExecuteAsync(request);
    }
}