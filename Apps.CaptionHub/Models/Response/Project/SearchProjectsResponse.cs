using Apps.CaptionHub.Models.Entities;

namespace Apps.CaptionHub.Models.Response.Project;

public record SearchProjectsResponse(List<ProjectEntity> Projects);
