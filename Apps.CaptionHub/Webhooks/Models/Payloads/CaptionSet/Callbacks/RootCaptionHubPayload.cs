using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.CaptionHub.Webhooks.Models.Payloads.CaptionSet.Callbacks
{
    public class RootCaptionHubPayload
    {
        [JsonProperty("data")]
        public CaptionSetCallbackResponse Data { get; set; }

        [JsonProperty("event")]
        public CaptionHubEvent Event { get; set; }
    }
    public class CaptionHubEvent
    {
        [JsonProperty("event_uid")]
        public string EventUid { get; set; }

        [JsonProperty("emitted_at")]
        public DateTime EmittedAt { get; set; }

        [JsonProperty("event_name")]
        public string EventName { get; set; }

        [JsonProperty("webhook_api_url")]
        public string WebhookApiUrl { get; set; }
    }
}
