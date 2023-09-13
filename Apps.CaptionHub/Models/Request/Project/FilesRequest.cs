using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Files;
using File = Blackbird.Applications.Sdk.Common.Files.File;

namespace Apps.CaptionHub.Models.Request.Project;

public class FilesRequest
{
    [Display("Original media URL")] public FileReference? OriginalMediaUrl { get; set; }
    [Display("Original media")] public File? OriginalMedia { get; set; }
}