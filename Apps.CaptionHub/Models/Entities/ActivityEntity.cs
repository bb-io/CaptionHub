using Apps.CaptionHub.Models.Entities.Simple;
using Blackbird.Applications.Sdk.Common;

namespace Apps.CaptionHub.Models.Entities;

public class ActivityEntity
{
    [Display("Activity ID")]
    public string Id { get; set; }

    public string By { get; set; }

    [Display("Owner Email")] public string OwnerEmail { get; set; }

    [Display("Owner ID")] public string OwnerId { get; set; }

    public DateTime At { get; set; }

    public string Key { get; set; }
    
    public SimpleProjectEntity Project { get; set; }

    [Display("Caption set ID")] public string CaptionSetId { get; set; }

    [Display("Recipient email")] public string RecipientEmail { get; set; }
}