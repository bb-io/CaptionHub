using Apps.CaptionHub.Constants;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Utils.Extensions.Sdk;
using Blackbird.Applications.Sdk.Utils.RestSharp;
using RestSharp;

namespace Apps.CaptionHub.Api;

public class CaptionHubRequest : BlackBirdRestRequest
{
    public CaptionHubRequest(string resource, Method method, IEnumerable<AuthenticationCredentialsProvider> creds) :
        base(resource, method, creds)
    {
    }

    protected override void AddAuth(IEnumerable<AuthenticationCredentialsProvider> creds)
    {
        var apiKey = creds.Get(CredsNames.ApiKey);
        this.AddHeader("Authorization", apiKey.Value);
    }
}