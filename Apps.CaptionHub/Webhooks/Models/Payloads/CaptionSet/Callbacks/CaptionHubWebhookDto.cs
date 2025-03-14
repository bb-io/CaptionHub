using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.CaptionHub.Webhooks.Models.Payloads.CaptionSet.Callbacks
{
    public class CaptionHubWebhookDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("subscribed_events")]
        public List<string> SubscribedEvents { get; set; }
    }
}
