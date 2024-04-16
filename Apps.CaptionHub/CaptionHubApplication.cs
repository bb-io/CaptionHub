using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Metadata;

namespace Apps.CaptionHub;

public class CaptionHubApplication : IApplication, ICategoryProvider
{
    public IEnumerable<ApplicationCategory> Categories
    {
        get => [ApplicationCategory.Multimedia];
        set { }
    }

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