using Apps.CaptionHub.Api;
using Apps.CaptionHub.Constants;
using Apps.CaptionHub.Invocables;
using Apps.CaptionHub.Models.Entities;
using Apps.CaptionHub.Models.Request.Project;
using Apps.CaptionHub.Models.Response.Project;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Exceptions;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Utils.Extensions.Http;
using Blackbird.Applications.Sdk.Utils.Extensions.Sdk;
using Blackbird.Applications.Sdk.Utils.Extensions.String;
using RestSharp;

namespace Apps.CaptionHub.Actions;

[ActionList("Projects")]
public class ProjectActions : CaptionHubInvocable
{
    public ProjectActions(InvocationContext invocationContext) : base(invocationContext)
    {
    }

    [Action("Search projects", Description = "Search projects")]
    public async Task<ListProjectsResponse> SearchProjects([ActionParameter] SearchProjectsRequest input)
    {
        var endpoint = ApiEndpoints.Projects.WithQuery(input);
        var request = new CaptionHubRequest(endpoint, Method.Get, Creds);

        var folderSlugs = await GetFolderSlugsAsync(input);

        foreach (var folderSlug in folderSlugs)
        {
            request.AddQueryParameter("folder_slug", folderSlug);
        }

        var response = await Client.Paginate<ProjectEntity>(request);
        return new(response);
    }

    private async Task<IEnumerable<string>> GetFolderSlugsAsync(SearchProjectsRequest input)
    {
        var selectedFolderSlugs = input.FolderSlugs?.Distinct().ToList() ?? new List<string>();

        if (!selectedFolderSlugs.Any() || input.IncludeAllSubfolders != true)
        {
            return selectedFolderSlugs;
        }

        var allFolders = await GetAllFoldersAsync();
        var selectedFolders = allFolders
            .Where(x => selectedFolderSlugs.Contains(x.Slug))
            .ToList();

        var foldersByParentId = allFolders
            .Where(x => x.ParentFolderId.HasValue)
            .GroupBy(x => x.ParentFolderId!.Value)
            .ToDictionary(x => x.Key, x => x.ToList());

        var allSelectedSlugs = new HashSet<string>(selectedFolderSlugs);
        var queue = new Queue<FolderEntity>(selectedFolders);

        while (queue.Count > 0)
        {
            var folder = queue.Dequeue();

            if (!foldersByParentId.TryGetValue(folder.Id, out var children))
                continue;

            foreach (var child in children)
            {
                if (allSelectedSlugs.Add(child.Slug))
                {
                    queue.Enqueue(child);
                }
            }
        }

        return allSelectedSlugs;
    }

    private async Task<List<FolderEntity>> GetAllFoldersAsync()
    {
        var result = new List<FolderEntity>();
        var queue = new Queue<int?>();
        queue.Enqueue(null);

        while (queue.Count > 0)
        {
            var parentFolderId = queue.Dequeue();
            var endpoint = ApiEndpoints.Folders;

            if (parentFolderId.HasValue)
            {
                endpoint = endpoint.SetQueryParameter("parent_folder_id", parentFolderId.Value.ToString());
            }

            var request = new CaptionHubRequest(endpoint, Method.Get, Creds);
            var folders = await Client.ExecuteWithErrorHandling<FolderEntity[]>(request);

            foreach (var folder in folders)
            {
                if (result.Any(x => x.Id == folder.Id))
                    continue;

                result.Add(folder);

                if (folder.ChildrenCount > 0)
                {
                    queue.Enqueue(folder.Id);
                }
            }
        }

        return result;
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

        if (files.OriginalMedia is null && files.OriginalMediaUrl is null)
            throw new PluginMisconfigurationException("You should mandatory specify one of the inputs: Original media or Original media URL");

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
