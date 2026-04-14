using Apps.CaptionHub.Api;
using Apps.CaptionHub.Constants;
using Apps.CaptionHub.Invocables;
using Apps.CaptionHub.Models.Entities;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Utils.Extensions.String;
using RestSharp;

namespace Apps.CaptionHub.DataSourceHandlers;

public class FolderDataHandler : CaptionHubInvocable, IAsyncDataSourceHandler
{
    public FolderDataHandler(InvocationContext invocationContext) : base(invocationContext)
    {
    }

    public async Task<Dictionary<string, string>> GetDataAsync(
        DataSourceContext context, CancellationToken cancellationToken)
    {
        var folders = await GetAllFoldersAsync();

        return folders
            .Where(x => context.SearchString is null ||
                        x.Name.Contains(context.SearchString, StringComparison.OrdinalIgnoreCase) ||
                        x.Slug.Contains(context.SearchString, StringComparison.OrdinalIgnoreCase))
            .OrderBy(x => x.Name)
            .Take(30)
            .ToDictionary(x => x.Slug, x => x.Name);
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
}
