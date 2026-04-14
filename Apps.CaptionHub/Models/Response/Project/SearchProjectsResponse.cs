using Apps.CaptionHub.Models.Entities;
using Blackbird.Applications.Sdk.Common;

namespace Apps.CaptionHub.Models.Response.Project;

public record SearchProjectsResponse(
    List<ProjectEntity> Projects,
    [property: Display("Applied folder slugs")] IEnumerable<string>? AppliedFolderSlugs = null,
    [property: Display("Include all subfolders")] bool? IncludeAllSubfolders = null);
