using Apps.CaptionHub.Models.Entities;

namespace Apps.CaptionHub.Models.Response.Project;

public record ListProjectsResponse(List<ProjectEntity> Projects);