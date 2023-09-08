using Apps.CaptionHub.Constants;
using Apps.CaptionHub.Models.Response;
using Blackbird.Applications.Sdk.Utils.Extensions.String;
using Blackbird.Applications.Sdk.Utils.RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestSharp;

namespace Apps.CaptionHub.Api;

public class CaptionHubClient : BlackBirdRestClient
{
    protected override JsonSerializerSettings? JsonSettings => new()
    {
        ContractResolver = new DefaultContractResolver()
        {
            NamingStrategy = new SnakeCaseNamingStrategy()
        }
    };

    public CaptionHubClient() : base(new()
    {
        BaseUrl = Urls.Api.ToUri()
    })
    {
    }

    protected override Exception ConfigureErrorException(RestResponse response)
    {
        var error = JsonConvert.DeserializeObject<ErrorResponse>(response.Content);
        return new(error.Error);
    }
}