using Blackbird.Applications.Sdk.Common.Dictionaries;

namespace Apps.CaptionHub.DataSourceHandlers.EnumHandleres;

public class ProjectPlatformDataHandler : IStaticDataSourceHandler
{
    public Dictionary<string, string> GetData() => new()
    {
        { "amazon_s3", "Amazon S3" },
        { "brightcove", "Brightcove" },
        { "cloudflare_stream", "Cloudflare Stream" },
        { "google_drive", "Google Drive" },
        { "jw_player", "JW Player" },
        { "kaltura", "Kaltura" },
        { "mux", "Mux" },
        { "qumu", "Qumu" },
        { "vcc", "VCC" },
        { "vimeo", "Vimeo" },
        { "youtube", "YouTube" }
    };
}
