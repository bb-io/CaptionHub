using Apps.CaptionHub.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.CaptionHub.Webhooks.Models.Inputs;

public class CaptionSetWebhookInput : ProjectWebhookInput
{
    [Display("Caption set ID")]
    public string? CaptionSetId { get; set; }

    [Display("Language")]
    [DataSource(typeof(LanguageIdDataHandler))]
    public string? LanguageId { get; set; }
}