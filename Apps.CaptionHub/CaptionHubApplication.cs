using Blackbird.Applications.Sdk.Common;

namespace Apps.CaptionHub;

public class CaptionHubApplication : IApplication
{
    public string Name
    {
        get => "CaptionHub";
        set { }
    }

    public T GetInstance<T>()
    {
        throw new NotImplementedException();
    }
}