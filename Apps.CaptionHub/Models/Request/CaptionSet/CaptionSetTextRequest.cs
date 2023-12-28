using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Files;

namespace Apps.CaptionHub.Models.Request.CaptionSet;

public class CaptionSetTextRequest
{
    [Display("Timed text")]
    public FileReference? TimedText { get; set; }
    
    [Display("Plain text")]
    public FileReference? PlainText { get; set; }
}