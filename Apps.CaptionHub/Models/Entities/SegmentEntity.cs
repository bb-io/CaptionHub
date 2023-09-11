using Blackbird.Applications.Sdk.Common;

namespace Apps.CaptionHub.Models.Entities;

public class SegmentEntity
{
    [Display("Segment ID")]
    public string Id { get; set; }

    [Display("Approved")]
    public string Approved { get; set; }

    [Display("Editor")]
    public string Editor { get; set; }

    [Display("Editor ID")]
    public string EditorId { get; set; }

    [Display("Workflow state")]
    public string WorkflowState { get; set; }
}