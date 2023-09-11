using Apps.CaptionHub.Models.Entities;
using Blackbird.Applications.Sdk.Common;

namespace Apps.CaptionHub.Models.Response.Workflow;

public record ListWorkflowTransitionsResponse([property: Display("Workflow transitions")]
    List<WorkflowTransitionEntity> WorkflowTransitions);