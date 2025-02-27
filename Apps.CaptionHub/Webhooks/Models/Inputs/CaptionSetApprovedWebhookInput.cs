using Apps.CaptionHub.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.CaptionHub.Webhooks.Models.Inputs
{
    public class CaptionSetApprovedWebhookInput : ProjectWebhookInput
    {
        [Display("Caption set ID")]
        public string? CaptionSetId { get; set; }

        [Display("Language ID")]
        [DataSource(typeof(LanguageIdDataHandler))]
        public IEnumerable<string>? LanguageIds { get; set; }
    }
}
