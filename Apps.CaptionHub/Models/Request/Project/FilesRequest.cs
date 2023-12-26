using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Files;

namespace Apps.CaptionHub.Models.Request.Project;

public class FilesRequest
{
    [Display("Original media")] public FileReference? OriginalMedia { get; set; }
    [Display("Original media URL")] public string? OriginalMediaUrl { get; set; }
}