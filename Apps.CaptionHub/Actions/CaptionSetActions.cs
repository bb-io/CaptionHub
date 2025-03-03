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
using Blackbird.Applications.SDK.Extensions.FileManagement.Interfaces;
using Blackbird.Applications.Sdk.Utils.Extensions.Http;
using Blackbird.Applications.Sdk.Utils.Extensions.String;
using RestSharp;
using Blackbird.Applications.Sdk.Common.Exceptions;
using Apps.CaptionHub.Models.Request.Project;

namespace Apps.CaptionHub.Actions;

[ActionList]
public class CaptionSetActions : CaptionHubInvocable
{
    private readonly IFileManagementClient _fileManagementClient;

    public CaptionSetActions(InvocationContext invocationContext, IFileManagementClient fileManagementClient) : base(
        invocationContext)
    {
        _fileManagementClient = fileManagementClient;
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

    [Action("Publish caption set", Description = "Publish a specific caption set")]
    public Task PublishCaptionSet([ActionParameter] CaptionSetRequest input)
    {
        var endpoint = $"{ApiEndpoints.CaptionSets}/{input.CaptionSetId}/publish";
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
        if (input.LanguageCode is null && input.LanguageId is null)
            throw new PluginMisconfigurationException("You should specify one of the inputs: Language code or Language ID");

        var action = new ProjectActions(InvocationContext);
        var project = action.GetProject(new ProjectRequest { ProjectId = input.ProjectId });
        if (project is null )
            throw new PluginMisconfigurationException("Your  project ID is incorrect please check your input and try again");

        var endpoint = $"{ApiEndpoints.CaptionSets}/translation";
        var request = new CaptionHubRequest(endpoint, Method.Post, Creds)
            .WithFormData(input, true, ignoreNullValues: true);

        return Client.ExecuteWithErrorHandling<CaptionSetEntity>(request);
    }

    [Action("Create original caption set", Description = "Create a new original caption set")]
    public async Task<CaptionSetEntity> CreateOriginalCaptionSet(
        [ActionParameter] CreateOriginalCaptionSetRequest input,
        [ActionParameter] CaptionSetTextRequest text)
    {
        if (input.LanguageCode is null && input.LanguageId is null)
            throw new PluginMisconfigurationException("You should specify one of the inputs: Language code or Language ID");

        var endpoint = $"{ApiEndpoints.CaptionSets}/original";
        var request = new CaptionHubRequest(endpoint, Method.Post, Creds)
            .WithFormData(input, true, ignoreNullValues: true);

        if (text.TimedText is not null)
        {
            var timedTextFile = await _fileManagementClient.DownloadAsync(text.TimedText);
            request = request.AddFile("timed_text", () => timedTextFile, text.TimedText.Name);
        }

        if (text.PlainText is not null)
        {
            var plainTextFile = await _fileManagementClient.DownloadAsync(text.PlainText);
            request = request.AddFile("plain_text", () => plainTextFile, text.PlainText.Name);
        }

        return await Client.ExecuteWithErrorHandling<CaptionSetEntity>(request);
    }

    [Action("Download original captions", Description = "Download an original caption set in the requested format")]
    public async Task<FileResponse> DownloadOriginalCaptions(
        [ActionParameter] DownloadOriginalCaptionSetRequest input)
    {
        var endpoint = $"{ApiEndpoints.CaptionSets}/original".WithQuery(input);
        var request = new CaptionHubRequest(endpoint, Method.Get, Creds);

        var response = await Client.ExecuteWithErrorHandling(request);
        var file = await _fileManagementClient.UploadAsync(new MemoryStream(response.RawBytes!),
            MediaTypeNames.Application.Octet, $"{input.ProjectId}-original.{input.CaptionsFormat}");

        return new()
        {
            File = file
        };
    }

    [Action("Download translated captions", Description = "Download a translated caption set in the requested format")]
    public async Task<FileResponse> DownloadTranslatedCaptions(
        [ActionParameter] DownloadTranslatedCaptionSetRequest input)
    {
        var endpoint = $"{ApiEndpoints.CaptionSets}/translation".WithQuery(input);
        var request = new CaptionHubRequest(endpoint, Method.Get, Creds);

        var response = await Client.ExecuteWithErrorHandling(request);

        var file = await _fileManagementClient.UploadAsync(new MemoryStream(response.RawBytes!),
            MediaTypeNames.Application.Octet, $"{input.CaptionSetId}.{input.CaptionsFormat}");

        return new()
        {
            File = file
        };
    }

    [Action("Update translation", Description = "Update translation caption set from a file")]
    public async Task UpdateTranslation([ActionParameter] UpdateTranslationRequest input)
    {
        if (input.LanguageCode is null && input.LanguageId is null)
            throw new PluginMisconfigurationException("You should specify one of the inputs: Language code or Language ID");

        var file = await _fileManagementClient.DownloadAsync(input.File);

        var endpoint = $"{ApiEndpoints.CaptionSets}/translation";
        var request = new CaptionHubRequest(endpoint, Method.Put, Creds)
        {
            AlwaysMultipartFormData = true
        }.AddFile("timed_text", () => file, input.File.Name);

        request.AddParameter("project_id", input.ProjectId);
        request.AddParameter("language_id", input.LanguageId);

        await Client.ExecuteWithErrorHandling(request);
    }
}