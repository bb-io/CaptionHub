using Apps.CaptionHub.Api;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.CaptionHub.Invocables;

public abstract class CaptionHubInvocable : BaseInvocable
{
    protected CaptionHubClient Client { get; }

    protected IEnumerable<AuthenticationCredentialsProvider> Creds =>
        InvocationContext.AuthenticationCredentialsProviders;

    protected CaptionHubInvocable(InvocationContext invocationContext)
        : base(invocationContext)
    {
        Client = new();
    }
}