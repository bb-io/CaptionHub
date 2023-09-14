﻿using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.CaptionHub.Webhooks.Models.Payloads.Project;

public class FullProjectPayload
{
    [Display("Project ID")]
    public string Id { get; set; }
    
    [Display("Project name")]
    [JsonProperty("name")]
    public string ProjectName { get; set; }   
}