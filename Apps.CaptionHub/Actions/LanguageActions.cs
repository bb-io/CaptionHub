using Apps.CaptionHub.Api;
using Apps.CaptionHub.Constants;
using Apps.CaptionHub.Invocables;
using Apps.CaptionHub.Models.Entities;
using Apps.CaptionHub.Models.Response.Language;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;
using RestSharp;

namespace Apps.CaptionHub.Actions;

public class LanguageActions : CaptionHubInvocable
{
    public LanguageActions(InvocationContext invocationContext) : base(invocationContext)
    {
    }
    
    [Action("List languages", Description = "List all available languages for your team")]
    public async Task<ListLanguagesResponse> ListLanguages()
    {
        var request = new CaptionHubRequest(ApiEndpoints.Languages, Method.Get, Creds);
        var response = await Client.ExecuteWithErrorHandling<LanguageEntity[]>(request);

        return new(response);
    }
}