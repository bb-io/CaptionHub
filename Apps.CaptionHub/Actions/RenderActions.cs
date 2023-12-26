using Apps.CaptionHub.Api;
using Apps.CaptionHub.Constants;
using Apps.CaptionHub.Invocables;
using Apps.CaptionHub.Models.Entities;
using Apps.CaptionHub.Models.Request.CaptionSet;
using Apps.CaptionHub.Models.Request.Render;
using Apps.CaptionHub.Models.Response;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.SDK.Extensions.FileManagement.Interfaces;
using Blackbird.Applications.Sdk.Utils.Utilities;
using RestSharp;

namespace Apps.CaptionHub.Actions;

[ActionList]
public class RenderActions : CaptionHubInvocable
{
    private readonly IFileManagementClient _fileManagementClient;

    public RenderActions(InvocationContext invocationContext, IFileManagementClient fileManagementClient) : base(
        invocationContext)
    {
        _fileManagementClient = fileManagementClient;
    }

    [Action("Get render status", Description = "Get status of a specific render")]
    public async Task<RenderingEntity> GetRenderStatus([ActionParameter] RenderRequest input)
    {
        var endpoint = $"{ApiEndpoints.CaptionSets}/{input.CaptionSetId}/renders/{input.RenderId}/status";
        var request = new CaptionHubRequest(endpoint, Method.Get, Creds);

        try
        {
            return await Client.ExecuteWithErrorHandling<RenderingEntity>(request);
        }
        catch (Exception ex)
        {
            if (ex.Message == "Bad Request")
                throw new("Could not find a render, perhaps it has been cancelled");

            throw;
        }
    }

    [Action("Create render", Description = "Create a render for the the given caption set")]
    public async Task<RenderingEntity> CreateRender([ActionParameter] CaptionSetRequest input)
    {
        var endpoint = $"{ApiEndpoints.CaptionSets}/{input.CaptionSetId}/renders";
        var request = new CaptionHubRequest(endpoint, Method.Post, Creds);

        var result = await Client.ExecuteWithErrorHandling<RenderingEntity>(request);

        while (result.Status == "rendering" || result.Status == "queued")
        {
            await Task.Delay(1000);
            result = await GetRenderStatus(new()
            {
                RenderId = result.Id,
                CaptionSetId = input.CaptionSetId
            });
        }

        return result;
    }

    [Action("Download render", Description = "Download completed render")]
    public async Task<FileResponse> DownloadRender([ActionParameter] RenderRequest input)
    {
        var render = await GetRenderStatus(input);

        if (render.Status != "completed")
            throw new("Render is not completed now, please try downloading it later");

        var endpoint = $"{ApiEndpoints.CaptionSets}/{input.CaptionSetId}/renders/{input.RenderId}/download_url";
        var request = new CaptionHubRequest(endpoint, Method.Post, Creds);

        var url = await Client.ExecuteWithErrorHandling<DownloadLinkEntity>(request);

        return new()
        {
            File = new(new(HttpMethod.Get, url.DownloadUrl))
            {
                Name = $"{input.CaptionSetId}-{input.RenderId}.mp4"
            }
        };
    }
}