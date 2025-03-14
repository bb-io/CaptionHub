using Apps.CaptionHub.Api;
using Apps.CaptionHub.Constants;
using Apps.CaptionHub.Models.Request.Webhook;
using Apps.CaptionHub.Webhooks.Models.Payloads.CaptionSet.Callbacks;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Common.Webhooks;
using Blackbird.Applications.Sdk.Utils.Extensions.Http;
using RestSharp;

namespace Apps.CaptionHub.Webhooks.Bridge.Base
{
    public class BaseWebhookBridgeHandler : BaseInvocable, IWebhookEventHandler
    {
        private readonly string _bridgeServiceUrl;

        private string SubscriptionEvent { get; set; }

        protected readonly CaptionHubClient Client;

        protected readonly string ProjectId;

        public BaseWebhookBridgeHandler(InvocationContext invocationContext, string subEvent, string projectId) : base(invocationContext)
        {
            SubscriptionEvent = subEvent;
            _bridgeServiceUrl = $"{invocationContext.UriInfo.BridgeServiceUrl.ToString().TrimEnd('/')}/webhooks/captionhubwebhook";
            Client = new CaptionHubClient();
            this.ProjectId = projectId;
        }

        public async Task SubscribeAsync(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
            Dictionary<string, string> values)
        {
            var bridge = new BridgeService(authenticationCredentialsProviders, _bridgeServiceUrl);
            string eventType = SubscriptionEvent;
            bridge.Subscribe(eventType, ProjectId, values["payloadUrl"]);
            var captionHubWebhookUrl = _bridgeServiceUrl;

            var getRequest = new CaptionHubRequest(ApiEndpoints.Webhooks, Method.Get, authenticationCredentialsProviders);
            var existingWebhooks = await Client.ExecuteWithErrorHandling<List<CaptionHubWebhookDto>>(getRequest);

            bool alreadyExists = existingWebhooks.Any(w =>
                w.Url == captionHubWebhookUrl &&
                w.SubscribedEvents != null &&
                w.SubscribedEvents.Contains(SubscriptionEvent));

            if (alreadyExists)
            {
                return;
            }

            var createWebhookRequest = new CreateWebhookRequest(captionHubWebhookUrl, new[] { SubscriptionEvent });
            var request = new CaptionHubRequest(ApiEndpoints.Webhooks, Method.Post, authenticationCredentialsProviders)
            .WithJsonBody(createWebhookRequest, JsonConfig.Settings);

            await Client.ExecuteWithErrorHandling(request);
        }

        public async Task UnsubscribeAsync(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
            Dictionary<string, string> values)
        {
            var bridge = new BridgeService(authenticationCredentialsProviders, _bridgeServiceUrl);
            bridge.Unsubscribe(SubscriptionEvent, ProjectId, values["payloadUrl"]);
        }
    }
}