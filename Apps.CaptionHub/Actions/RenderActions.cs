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
using Blackbird.Applications.Sdk.Utils.Utilities;
using RestSharp;

namespace Apps.CaptionHub.Actions;

[ActionList]
public class RenderActions : CaptionHubInvocable
{
    public RenderActions(InvocationContext invocationContext) : base(invocationContext)
    {
    }

    [Action("Get render status", Description = "Get status of a specific render")]
    public Task<RenderingEntity> GetRenderStatus([ActionParameter] RenderRequest input)
    {
        var endpoint = $"{ApiEndpoints.CaptionSets}/{input.CaptionSetId}/renders/{input.RenderId}/status";
        var request = new CaptionHubRequest(endpoint, Method.Get, Creds);

        return Client.ExecuteWithErrorHandling<RenderingEntity>(request);
    }

    [Action("Create render", Description = "Create a render for the the given caption set")]
    public Task<RenderingEntity> CreateRender([ActionParameter] CaptionSetRequest input)
    {
        var endpoint = $"{ApiEndpoints.CaptionSets}/{input.CaptionSetId}/renders";
        var request = new CaptionHubRequest(endpoint, Method.Post, Creds);

        return Client.ExecuteWithErrorHandling<RenderingEntity>(request);
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

        var file = await FileDownloader.DownloadFileBytes(url.DownloadUrl);
        file.Name = $"{input.CaptionSetId}-{input.RenderId}.mp4";

        return new()
        {
            File = file
        };
    }
}