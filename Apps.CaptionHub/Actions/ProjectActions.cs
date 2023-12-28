using Apps.CaptionHub.Api;
using Apps.CaptionHub.Constants;
using Apps.CaptionHub.Invocables;
using Apps.CaptionHub.Models.Entities;
using Apps.CaptionHub.Models.Request.Project;
using Apps.CaptionHub.Models.Response.Project;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Utils.Extensions.Http;
using Blackbird.Applications.Sdk.Utils.Extensions.Sdk;
using Blackbird.Applications.Sdk.Utils.Extensions.String;
using RestSharp;

namespace Apps.CaptionHub.Actions;

[ActionList]
public class ProjectActions : CaptionHubInvocable
{
    public ProjectActions(InvocationContext invocationContext) : base(invocationContext)
    {
    }

    [Action("List projects", Description = "List all projects")]
    public async Task<ListProjectsResponse> ListProjects()
    {
        var request = new CaptionHubRequest(ApiEndpoints.Projects, Method.Get, Creds);

        var response = await Client.Paginate<ProjectEntity>(request);
        return new(response);
    }

    [Action("Create project", Description = "Create a new project")]
    public Task<ProjectEntity> CreateProject([ActionParameter] CreateProjectRequest input,
        [ActionParameter] FilesRequest files)
    {
        if (input.StatusCallbackUrl is null)
        {
            var id = Creds.Get(CredsNames.ApiKey).Value.Hash();
            input.StatusCallbackUrl =
                InvocationContext.UriInfo.BridgeServiceUrl.ToString().SetQueryParameter("id", id);
        }

        var request = new CaptionHubRequest(ApiEndpoints.Projects, Method.Post, Creds)
            .WithFormData(input, true, ignoreNullValues: true)
            .AddParameter("original_media_url", (files.OriginalMedia?.Url ?? files.OriginalMediaUrl) ?? string.Empty);

        return Client.ExecuteWithErrorHandling<ProjectEntity>(request);
    }

    [Action("Update project", Description = "Update an existing project")]
    public Task<ProjectEntity> UpdateProject(
        [ActionParameter] ProjectRequest project,
        [ActionParameter] UpdateProjectRequest input)
    {
        var endpoint = $"{ApiEndpoints.Projects}/{project.ProjectId}";
        var request = new CaptionHubRequest(endpoint, Method.Put, Creds)
            .WithJsonBody(input, JsonConfig.Settings);

        return Client.ExecuteWithErrorHandling<ProjectEntity>(request);
    }

    [Action("Get project", Description = "Get details of an existing project")]
    public Task<ProjectEntity> GetProject([ActionParameter] ProjectRequest project)
    {
        var endpoint = $"{ApiEndpoints.Projects}/{project.ProjectId}";
        var request = new CaptionHubRequest(endpoint, Method.Get, Creds);

        return Client.ExecuteWithErrorHandling<ProjectEntity>(request);
    }

    [Action("Wait until project has original caption set",
        Description =
            "Wait until a caption set is present on a project. Use in conjunction with CaptionHub automations.")]
    public async Task<ProjectEntity> WaitUntilCaptionSet([ActionParameter] ProjectRequest project)
    {
        var endpoint = $"{ApiEndpoints.Projects}/{project.ProjectId}";
        var request = new CaptionHubRequest(endpoint, Method.Get, Creds);

        ProjectResponse? result = null;

        while (result?.OriginalCaptionSet is null || result.OriginalCaptionSet.PercentageComplete < 100)
        {
            await Task.Delay(3000);
            result = await Client.ExecuteWithErrorHandling<ProjectResponse>(request);
        }

        return new(result);
    }

    [Action("Delete project", Description = "Delete specific project")]
    public Task DeleteProject([ActionParameter] ProjectRequest project)
    {
        var endpoint = $"{ApiEndpoints.Projects}/{project.ProjectId}";
        var request = new CaptionHubRequest(endpoint, Method.Delete, Creds);

        return Client.ExecuteWithErrorHandling(request);
    }

    [Action("Replace the video for a project", Description = "Replace the video for a specific project")]
    public Task<ProjectEntity> ReplaceProjectVideo(
        [ActionParameter] ProjectRequest project,
        [ActionParameter] ReplaceVideoRequest input)
    {
        var endpoint = $"{ApiEndpoints.Projects}/{project.ProjectId}/video";
        var request = new CaptionHubRequest(endpoint, Method.Put, Creds)
            .WithFormData(input, true);

        return Client.ExecuteWithErrorHandling<ProjectEntity>(request);
    }
}