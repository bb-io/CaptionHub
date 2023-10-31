﻿using Apps.CaptionHub.Webhooks.Handlers.Base;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.CaptionHub.Webhooks.Handlers;

public class AutomaticTranscriptionFailedHandler : CaptionHubWebhookHandler
{
    protected override string Event => "automaticTranscriptionFailed";

    public AutomaticTranscriptionFailedHandler(InvocationContext invocationContext) : base(invocationContext)
    {
    }
}