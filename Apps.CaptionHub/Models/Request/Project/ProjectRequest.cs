using Blackbird.Applications.Sdk.Common;

namespace Apps.CaptionHub.Models.Request.Project;

public class ProjectRequest
{
    [Display("Project ID")] public string ProjectId { get; set; }
}