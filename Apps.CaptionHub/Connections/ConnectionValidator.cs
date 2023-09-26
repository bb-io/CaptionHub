using Apps.CaptionHub.Api;
using Apps.CaptionHub.Constants;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Connections;
using RestSharp;

namespace Apps.CaptionHub.Connections;

public class ConnectionValidator : IConnectionValidator
{
    public async ValueTask<ConnectionValidationResponse> ValidateConnection(
        IEnumerable<AuthenticationCredentialsProvider> authProviders, CancellationToken cancellationToken)
    {
        var client = new CaptionHubClient();
        var request = new CaptionHubRequest(ApiEndpoints.Teams, Method.Get, authProviders);

        try
        {
            await client.ExecuteWithErrorHandling(request);

            return new()
            {
                IsValid = true
            };
        }
        catch (Exception ex)
        {
            return new()
            {
                IsValid = false,
                Message = ex.Message
            };
        }
    }
}