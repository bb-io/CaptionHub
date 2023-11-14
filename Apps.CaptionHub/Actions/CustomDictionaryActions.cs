using Apps.CaptionHub.Api;
using Apps.CaptionHub.Constants;
using Apps.CaptionHub.Invocables;
using Apps.CaptionHub.Models.Entities;
using Apps.CaptionHub.Models.Request.CustomDictionary;
using Apps.CaptionHub.Models.Response.CustomDictionary;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Utils.Extensions.Http;
using RestSharp;

namespace Apps.CaptionHub.Actions;

[ActionList]
public class CustomDictionaryActions : CaptionHubInvocable
{
    public CustomDictionaryActions(InvocationContext invocationContext) : base(invocationContext)
    {
    }

    [Action("List custom dictionaries", Description = "List all custom dictionaries belonging to your team")]
    public async Task<ListCustomDictionariesResponse> ListCustomDictionaries()
    {
        var request = new CaptionHubRequest(ApiEndpoints.CustomDictionary, Method.Get, Creds);

        var response = await Client.ExecuteWithErrorHandling<CustomDictionaryResponse[]>(request);
        var result = response
            .Select(x => new CustomDictionaryEntity(x))
            .ToArray();

        return new(result);
    }

    [Action("Get custom dictionary", Description = "Get details of a specific custom dictionary")]
    public async Task<CustomDictionaryEntity> GetCustomDictionary([ActionParameter] CustomDictionaryRequest input)
    {
        var endpoint = $"{ApiEndpoints.CustomDictionary}/{input.CustomDictionaryId}";
        var request = new CaptionHubRequest(endpoint, Method.Get, Creds);

        var response = await Client.ExecuteWithErrorHandling<CustomDictionaryResponse>(request);
        return new(response);
    }

    //TODO: Find out cause of "Server error" exception
    // [Action("Activate custom dictionary",
    //     Description = "Get the status of a custom dictionary on the supplied provider")]
    // public Task<ActivateCustomDictionaryResponse> ActivateCustomDictionary()
    // {
    //     var request = new CaptionHubRequest("/custom_dictionary_activations", Method.Post, Creds)
    //         .WithJsonBody(new
    //         {
    //             custom_dictionary_id = "601",
    //             providers = new[] { "aws" }
    //         });
    //     return Client.ExecuteWithErrorHandling<ActivateCustomDictionaryResponse>(request);
    // }
}