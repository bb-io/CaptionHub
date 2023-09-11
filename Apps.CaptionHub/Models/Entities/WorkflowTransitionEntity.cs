using Apps.CaptionHub.Models.Entities.Simple;
using Blackbird.Applications.Sdk.Common;

namespace Apps.CaptionHub.Models.Entities;

public class WorkflowTransitionEntity
{
    [Display("Workflow transition ID")] public string Id { get; set; }

    public DateTime At { get; set; }

    [Display("Workflow type")] public string WorkflowType { get; set; }

    [Display("Transition name")] public string TransitionName { get; set; }

    public SimpleUserEntity User { get; set; }

    public SimpleSegmentEntity Segment { get; set; }

    [Display("Caption set")] public SimpleCaptionSetEntity CaptionSet { get; set; }

    public SimpleProjectEntity Project { get; set; }

    public TeamEntity Team { get; set; }
}