namespace Apps.CaptionHub.Models.Response;

public class MultipleErrorResponse
{
    public IEnumerable<string> Error { get; set; }
}