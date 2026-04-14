using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Files;

namespace Apps.CaptionHub.Models.Response;

public class FileResponse
{
    public FileReference File { get; set; }

    [Display("Caption set ID")]
    public string? CaptionSetId { get; set; }
}
