using System.Web;
using Apps.CaptionHub.Constants;
using Apps.CaptionHub.Models.Response;
using Blackbird.Applications.Sdk.Common.Exceptions;
using Blackbird.Applications.Sdk.Utils.Extensions.String;
using Blackbird.Applications.Sdk.Utils.RestSharp;
using Newtonsoft.Json;
using RestSharp;

namespace Apps.CaptionHub.Api;

public class CaptionHubClient : BlackBirdRestClient
{
    protected override JsonSerializerSettings? JsonSettings => JsonConfig.Settings;

    public CaptionHubClient() : base(new()
    {
        BaseUrl = Urls.Api.ToUri()
    })
    {
    }

    protected override Exception ConfigureErrorException(RestResponse response)
    {
        var responseContent = HttpUtility.HtmlDecode(response.Content);
        var errorMessage = GetErrorMessage(responseContent);

        errorMessage = errorMessage.Contains("Server error")
            ? "Something went wrong, you should check your inputs"
            : errorMessage;
        throw new PluginApplicationException(errorMessage);
    }

    private string? GetErrorMessage(string? responseContent)
    {
        try
        {
            return JsonConvert.DeserializeObject<ErrorResponse>(responseContent).Error;
        }
        catch
        {
            var multipleErrorResponse = JsonConvert.DeserializeObject<MultipleErrorResponse>(responseContent);
            return string.Join(';', multipleErrorResponse.Error);
        }
    }

    public async Task<List<T>> Paginate<T>(CaptionHubRequest request)
    {
        var result = new List<T>();
        var url = request.Resource;

        var page = 1;
        T[] response;

        do
        {
            request.Resource = url.SetQueryParameter("page", (page++).ToString());
            response = await ExecuteWithErrorHandling<T[]>(request);

            result.AddRange(response);
        } while (response.Any());

        return result;
    }
}