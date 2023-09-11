using System.Net.Mime;
using Apps.CaptionHub.Api;
using Apps.CaptionHub.Constants;
using Apps.CaptionHub.Invocables;
using Apps.CaptionHub.Models.Entities;
using Apps.CaptionHub.Models.Entities.Simple;
using Apps.CaptionHub.Models.Request.CaptionSet;
using Apps.CaptionHub.Models.Response;
using Apps.CaptionHub.Models.Response.CaptionSet;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Utils.Extensions.Http;
using Blackbird.Applications.Sdk.Utils.Extensions.String;
using RestSharp;

namespace Apps.CaptionHub.Actions;

[ActionList]
public class CaptionSetActions : CaptionHubInvocable
{
    public CaptionSetActions(InvocationContext invocationContext) : base(invocationContext)
    {
    }
    
    [Action("List caption sets", Description = "List caption sets assigned to a user")]
    public async Task<ListCaptionSetsResponse> ListCaptionSets(
        [ActionParameter] [Display("Email")] string email)
    {
        var endpoint = $"{ApiEndpoints.CaptionSets}/assigned_to_user"
            .SetQueryParameter("email", email);
        var request = new CaptionHubRequest(endpoint, Method.Get, Creds);
        
        var response = await Client.ExecuteWithErrorHandling<SimpleCaptionSetEntity[]>(request);
        return new(response);
    }    
    
    [Action("Approve caption set", Description = "Mark all segments in a caption set as approved")]
    public Task ApproveCaptionSet([ActionParameter] CaptionSetRequest input)
    {
        var endpoint = $"{ApiEndpoints.CaptionSets}/{input.CaptionSetId}/mark_approved";
        var request = new CaptionHubRequest(endpoint, Method.Put, Creds);

        return Client.ExecuteWithErrorHandling(request);
    }     
    
    [Action("Make caption set reviewable", Description = "Make all segments in a caption set reviewable")]
    public Task MakeCaptionSetReviewable([ActionParameter] CaptionSetRequest input)
    {
        var endpoint = $"{ApiEndpoints.CaptionSets}/{input.CaptionSetId}/mark_reviewable";
        var request = new CaptionHubRequest(endpoint, Method.Put, Creds);

        return Client.ExecuteWithErrorHandling(request);
    }     
    
    [Action("Make caption set claimable", Description = "Make all segments in a caption set claimable")]
    public Task MakeCaptionSetClaimable([ActionParameter] CaptionSetRequest input)
    {
        var endpoint = $"{ApiEndpoints.CaptionSets}/{input.CaptionSetId}/mark_claimable";
        var request = new CaptionHubRequest(endpoint, Method.Put, Creds);

        return Client.ExecuteWithErrorHandling(request);
    }     
    
    [Action("Create translated caption set", Description = "Create a caption set ready for translation")]
    public Task<CaptionSetEntity> CreateTranslatedCaptionSet(
        [ActionParameter] CreateTranslatedCaptionSetRequest input)
    {
        var endpoint = $"{ApiEndpoints.CaptionSets}/translation";
        var request = new CaptionHubRequest(endpoint, Method.Post, Creds)
            .WithFormData(input, true, ignoreNullValues: true);
        
        return Client.ExecuteWithErrorHandling<CaptionSetEntity>(request);
    }   
    
    // TODO: investigate server error
    [Action("Create original caption set", Description = "Create a new original caption set")]
    public Task<CaptionSetEntity> CreateOriginalCaptionSet(
        [ActionParameter] CreateOriginalCaptionSetRequest input,
        [ActionParameter] CaptionSetTextRequest text)
    {
        var endpoint = $"{ApiEndpoints.CaptionSets}/original";
        var request = new CaptionHubRequest(endpoint, Method.Post, Creds)
            .WithFormData(input, true, ignoreNullValues: true);

        if (text.TimedText is not null)
            request = request.WithFile(text.TimedText.Bytes, text.TimedText.Name, "timed_text");
        
        if (text.PlainText is not null)
            request = request.WithFile(text.PlainText.Bytes, text.PlainText.Name, "plain_text");
        
        return Client.ExecuteWithErrorHandling<CaptionSetEntity>(request);
    }    
    
    // TODO: investigate server error
    [Action("Download original captions", Description = "Download an original caption set in the requested format")]
    public async Task<FileResponse> DownloadOriginalCaptions(
        [ActionParameter] DownloadOriginalCaptionSetRequest input)
    {
        var endpoint = $"{ApiEndpoints.CaptionSets}/original".WithQuery(input);
        var request = new CaptionHubRequest(endpoint, Method.Get, Creds);

        var response = await Client.ExecuteWithErrorHandling(request);
        return new()
        {
            File = new(response.RawBytes)
            {
                Name = $"{input.ProjectId}-original.{input.CaptionsFormat}",
                ContentType = MediaTypeNames.Application.Octet
            }
        };
    }    
    
    // TODO: test
    [Action("Download translated captions", Description = "Download a translated caption set in the requested format")]
    public async Task<FileResponse> DownloadTranslatedCaptions(
        [ActionParameter] DownloadTranslatedCaptionSetRequest input)
    {
        var endpoint = $"{ApiEndpoints.CaptionSets}/translation".WithQuery(input);
        var request = new CaptionHubRequest(endpoint, Method.Get, Creds);

        var response = await Client.ExecuteWithErrorHandling(request);
        return new()
        {
            File = new(response.RawBytes)
            {
                Name = $"{input.CaptionSetId}.{input.CaptionsFormat}",
                ContentType = MediaTypeNames.Application.Octet
            }
        };
    }
}