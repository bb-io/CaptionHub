using Blackbird.Applications.Sdk.Common;

namespace Apps.CaptionHub.Models.Entities.Simple;

public class SimpleSegmentEntity
{
    [Display("Segment ID")]
    public string Id { get; set; }
    
    public string Approved { get; set; }
    
    public string Editor { get; set; }
    
    [Display("Editor ID")]
    public string EditorId { get; set; }
    
    [Display("Workflow state")]
    public string WorkflowState { get; set; }
}