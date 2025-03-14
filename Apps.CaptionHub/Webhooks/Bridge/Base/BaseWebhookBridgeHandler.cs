﻿using Apps.CaptionHub.Constants;
using Apps.CaptionHub.Models.Response.User;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Common.Webhooks;
using Blackbird.Applications.Sdk.Common;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apps.CaptionHub.Api;
using Apps.CaptionHub.Actions;

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
        }

        public async Task UnsubscribeAsync(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
            Dictionary<string, string> values)
        {
                var bridge = new BridgeService(authenticationCredentialsProviders, _bridgeServiceUrl);;
                bridge.Unsubscribe(SubscriptionEvent, ProjectId, values["payloadUrl"]);
        }
    }
}