using Apps.CaptionHub.Models.Entities.Simple;

namespace Apps.CaptionHub.Models.Response.CaptionSet;

public record ListCaptionSetsResponse(SimpleCaptionSetEntity[] Captions);