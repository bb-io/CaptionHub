using Blackbird.Applications.Sdk.Common;
using File = Blackbird.Applications.Sdk.Common.Files.File;

namespace Apps.CaptionHub.Models.Request.CaptionSet;

public class CaptionSetTextRequest
{
    [Display("Timed text")]
    public File? TimedText { get; set; }
    
    [Display("Plain text")]
    public File? PlainText { get; set; }
}