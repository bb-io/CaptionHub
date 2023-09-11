using Apps.CaptionHub.Models.Entities;

namespace Apps.CaptionHub.Models.Response.Activity;

public record ListActivitiesResponse(List<ActivityEntity> Activities);