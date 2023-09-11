using Blackbird.Applications.Sdk.Common;

namespace Apps.CaptionHub.Models.Entities.Simple;

public class SimpleUserEntity
{
    [Display("User ID")]
    public string Id { get; set; }
    
    public string Email { get; set; }
    
    [Display("Authentication provider ID")]
    public string? AuthProviderId { get; set; }
}