﻿using Apps.CaptionHub.Constants;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Utils.Extensions.Sdk;
using Blackbird.Applications.Sdk.Utils.Extensions.String;
using Blackbird.Applications.Sdk.Utils.Webhooks.Bridge;
using Blackbird.Applications.Sdk.Utils.Webhooks.Bridge.Models.Request;

namespace Apps.CaptionHub.Webhooks.Handlers.CallbackHandlers.Base;

public abstract class CaptionHubBridgeWebhookHandler : InvocableBridgeWebhookHandler
{
    protected abstract string Event { get; }

    protected CaptionHubBridgeWebhookHandler(InvocationContext invocationContext) : base(invocationContext)
    {
    }

    protected override Task<(BridgeRequest webhookData, BridgeCredentials bridgeCreds)> GetBridgeServiceInputs(
        Dictionary<string, string> values, IEnumerable<AuthenticationCredentialsProvider> creds)
    {
        var webhookData = new BridgeRequest
        {
            Event = Event,
            Id = creds.Get(CredsNames.ApiKey).Value.Hash(),
            Url = values["payloadUrl"],
        };

        var bridgeCreds = new BridgeCredentials
        {
            ServiceUrl = InvocationContext.UriInfo.BridgeServiceUrl.ToString(),
            Token = ApplicationConstants.BlackbirdToken
        };

        return Task.FromResult((webhookData, bridgeCreds));
    }
}