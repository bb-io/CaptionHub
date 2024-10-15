using Apps.CaptionHub.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.CaptionHub.Webhooks.Models.Inputs;

public class ProjectWebhookInput
{
    [Display("Project")]
    [DataSource(typeof(ProjectDataHandler))]
    public string? ProjectId { get; set; }
}