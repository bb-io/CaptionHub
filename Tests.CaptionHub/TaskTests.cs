using Apps.CaptionHub.Actions;
using Apps.CaptionHub.Models.Request.CaptionSet;
using Apps.CaptionHub.Models.Request.Project;
using Apps.CaptionHub.Webhooks;
using Apps.CaptionHub.Webhooks.Models.Inputs;
using Blackbird.Applications.Sdk.Common.Webhooks;
using Newtonsoft.Json;
using Tests.CaptionHub.Base;

namespace Tests.CaptionHub
{
    [TestClass]
    public class TaskTests : TestBase
    {
        [TestMethod]
        public async Task CreateProject_ReturnSucces()
        {
            var action = new ProjectActions(InvocationContext);
            var createProjectRequest = new CreateProjectRequest { Name = "TestProject"};
            var filesRequest = new FilesRequest { OriginalMediaUrl = "https://drive.google.com/file/d/1AlCl-QFhJpr_55aVb39lyKrzQ2qUVGOT/view?usp=sharing&t=5" };
            var response = await action.CreateProject(createProjectRequest, filesRequest);

            Console.WriteLine(response.Id);
            Assert.IsNotNull(response);
        }


        [TestMethod]
        public async Task CreateCaptionSet_ReturnSucces()
        {
            var action = new CaptionSetActions(InvocationContext, FileManager);
            var createProjectRequest = new CreateOriginalCaptionSetRequest { ProjectId= "278143", LanguageId="6"};
            var filesRequest = new CaptionSetTextRequest { };
            var response = await action.CreateOriginalCaptionSet(createProjectRequest, filesRequest);

            Console.WriteLine(response.Id);
            Assert.IsNotNull(response);
        }



        [TestMethod]
        public async Task CreateTranslationCaptionSet_ReturnSucces()
        {
            var action = new CaptionSetActions(InvocationContext, FileManager);
            var createProjectRequest = new CreateTranslatedCaptionSetRequest 
            { 
                ProjectId = "278143", 
                LanguageCode = "ES", 
                TranslationProvider="amazon" ,
                Autotranslation = true
            };

            var response = await action.CreateTranslatedCaptionSet(createProjectRequest);

            Console.WriteLine(response.Id);
            Assert.IsNotNull(response);
        }


        [TestMethod]
        public async Task GetProject_ReturnSucces()
        {
            var action = new ProjectActions(InvocationContext);
            var createProjectRequest = new ProjectRequest { ProjectId = "278143" };
            var response = await action.GetProject(createProjectRequest);

            Console.WriteLine(response.Id);
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public async Task MakeCaptionSetClaimable_ReturnSucces()
        {
            var action = new CaptionSetActions(InvocationContext,FileManager);
            var createProjectRequest = new CaptionSetRequest { CaptionSetId = "" };
            await action.MakeCaptionSetClaimable(createProjectRequest);
            Assert.IsTrue(true);
        }




        [TestMethod]
        public async Task OnCaptionSetApproved_ReturnSucces()
        {
            var webhookRequest = new WebhookRequest
            {
                Body = jsonPayload,
                Headers = new Dictionary<string, string>(),
                HttpMethod = HttpMethod.Post,
                QueryParameters = new Dictionary<string, string>(),
                Url = "https://dummyurl"
            };

            var input = new CaptionSetApprovedWebhookInput
            {
                ProjectId = "278143",
                //CaptionSetId = "",
                LanguageIds = new List<string> { "84" }
            };

            var callback = new CallbackList();

            var response = await callback.OnCaptionSetApproved(webhookRequest, input);

            var resultJson = JsonConvert.SerializeObject(response.Result, Formatting.Indented);
            Console.WriteLine(resultJson);

            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Result);
        }
        private readonly string jsonPayload = @"
{
  ""data"": {
    ""project"": {
      ""id"": 278143,
      ""name"": ""TestProject2"",
      ""slug"": ""5838b6ff568b"",
      ""notes"": null,
      ""ready"": true,
      ""width"": 1080,
      ""height"": 1920,
      ""duration"": 5.37,
      ""platform"": null,
      ""tag_list"": [],
      ""framerate"": 29.981,
      ""created_at"": ""2025-02-19T17:26:12.786Z"",
      ""word_count"": 2,
      ""description"": null,
      ""video_title"": null,
      ""caption_sets"": [
        {
          ""id"": 2935703,
          ""slug"": ""b043f28d0c67"",
          ""ready"": true,
          ""language"": {
            ""id"": 84,
            ""name"": ""Spanish"",
            ""code_and_territory"": ""ES"",
            ""spellcheck_enabled"": true,
            ""territory_and_code"": ""ES"",
            ""amazon_polly_enabled"": true,
            ""auto_align_available"": false,
            ""deepl_translate_enabled"": true,
            ""live_transcribe_enabled"": true,
            ""amazon_translate_enabled"": true,
            ""google_translate_enabled"": true,
            ""live_translation_enabled"": true,
            ""amazon_transcribe_enabled"": true,
            ""auto_transcribe_available"": null,
            ""scriptix_transcribe_enabled"": true,
            ""speechmatics_transcribe_enabled"": true,
            ""language_weaver_translate_enabled"": true,
            ""eleven_labs_multilingual_v2_enabled"": true
          },
          ""segments"": [
            {
              ""id"": 2948893,
              ""editor"": null,
              ""approved?"": false,
              ""editor_id"": null,
              ""workflow_state"": ""ready""
            }
          ],
          ""renderings"": [],
          ""apply_limits_to"": ""t1_and_t2"",
          ""connect_request_id"": null,
          ""latest_snapshot_id"": 6794869,
          ""maximum_line_count"": 2,
          ""percentage_complete"": 100,
          ""maximum_character_count"": 45,
          ""maximum_caption_duration"": 10.0,
          ""minimum_caption_duration"": 1.0,
          ""minimum_frames_between_captions"": 0
        },
        {
          ""id"": 2935691,
          ""slug"": ""39028a311995"",
          ""ready"": true,
          ""language"": {
            ""id"": 51,
            ""name"": ""Catalan (Spain)"",
            ""code_and_territory"": ""CA-ES"",
            ""spellcheck_enabled"": false,
            ""territory_and_code"": ""ES-CA"",
            ""amazon_polly_enabled"": true,
            ""auto_align_available"": false,
            ""deepl_translate_enabled"": false,
            ""live_transcribe_enabled"": false,
            ""amazon_translate_enabled"": true,
            ""google_translate_enabled"": true,
            ""live_translation_enabled"": true,
            ""amazon_transcribe_enabled"": true,
            ""auto_transcribe_available"": null,
            ""scriptix_transcribe_enabled"": false,
            ""speechmatics_transcribe_enabled"": true,
            ""language_weaver_translate_enabled"": true,
            ""eleven_labs_multilingual_v2_enabled"": false
          },
          ""segments"": [
            {
              ""id"": 2948881,
              ""editor"": null,
              ""approved?"": true,
              ""editor_id"": null,
              ""workflow_state"": ""approved""
            }
          ],
          ""renderings"": [],
          ""apply_limits_to"": ""t1_and_t2"",
          ""connect_request_id"": null,
          ""latest_snapshot_id"": 6794860,
          ""maximum_line_count"": 2,
          ""percentage_complete"": 100,
          ""maximum_character_count"": 45,
          ""maximum_caption_duration"": 10.0,
          ""minimum_caption_duration"": 1.0,
          ""minimum_frames_between_captions"": 0
        }
      ],
      ""termbase_ids"": [],
      ""automation_id"": null,
      ""platform_media_id"": null,
      ""customer_reference"": null,
      ""original_caption_set"": {
        ""id"": 2909923,
        ""slug"": ""d7a0b3545d68"",
        ""ready"": true,
        ""language"": {
          ""id"": 6,
          ""name"": ""Danish"",
          ""code_and_territory"": ""DA"",
          ""spellcheck_enabled"": true,
          ""territory_and_code"": ""DA"",
          ""amazon_polly_enabled"": true,
          ""auto_align_available"": false,
          ""deepl_translate_enabled"": true,
          ""live_transcribe_enabled"": true,
          ""amazon_translate_enabled"": true,
          ""google_translate_enabled"": true,
          ""live_translation_enabled"": true,
          ""amazon_transcribe_enabled"": true,
          ""auto_transcribe_available"": null,
          ""scriptix_transcribe_enabled"": true,
          ""speechmatics_transcribe_enabled"": true,
          ""language_weaver_translate_enabled"": true,
          ""eleven_labs_multilingual_v2_enabled"": true
        },
        ""segments"": [
          {
            ""id"": 2923292,
            ""editor"": null,
            ""approved?"": true,
            ""editor_id"": null,
            ""workflow_state"": ""approved""
          }
        ],
        ""renderings"": [
          {
            ""id"": 79931,
            ""status"": ""failed"",
            ""created_at"": ""2025-02-19T17:42:37.967Z"",
            ""caption_set_id"": 2909923
          }
        ],
        ""apply_limits_to"": ""t1_and_t2"",
        ""connect_request_id"": null,
        ""latest_snapshot_id"": 6809535,
        ""maximum_line_count"": 2,
        ""percentage_complete"": 100,
        ""maximum_character_count"": 45,
        ""maximum_caption_duration"": 10.0,
        ""minimum_caption_duration"": 1.0,
        ""minimum_frames_between_captions"": 0
      },
      ""timecode_start_string"": null,
      ""translations_workflow_type"": ""assignable"",
      ""original_captions_workflow_type"": ""assignable""
    },
    ""caption_set"": {
      ""id"": 2909923,
      ""slug"": ""d7a0b3545d68"",
      ""ready"": true,
      ""language"": {
        ""id"": 6,
        ""name"": ""Danish"",
        ""code_and_territory"": ""DA"",
        ""spellcheck_enabled"": true,
        ""territory_and_code"": ""DA"",
        ""amazon_polly_enabled"": true,
        ""auto_align_available"": false,
        ""deepl_translate_enabled"": true,
        ""live_transcribe_enabled"": true,
        ""amazon_translate_enabled"": true,
        ""google_translate_enabled"": true,
        ""live_translation_enabled"": true,
        ""amazon_transcribe_enabled"": true,
        ""auto_transcribe_available"": null,
        ""scriptix_transcribe_enabled"": true,
        ""speechmatics_transcribe_enabled"": true,
        ""language_weaver_translate_enabled"": true,
        ""eleven_labs_multilingual_v2_enabled"": true
      },
      ""segments"": [
        {
          ""id"": 2923292,
          ""editor"": null,
          ""approved?"": true,
          ""editor_id"": null,
          ""workflow_state"": ""approved""
        }
      ],
      ""renderings"": [
        {
          ""id"": 79931,
          ""status"": ""failed"",
          ""created_at"": ""2025-02-19T17:42:37.967Z"",
          ""caption_set_id"": 2909923
        }
      ],
      ""apply_limits_to"": ""t1_and_t2"",
      ""connect_request_id"": null,
      ""latest_snapshot_id"": 6809535,
      ""maximum_line_count"": 2,
      ""percentage_complete"": 100,
      ""maximum_character_count"": 45,
      ""maximum_caption_duration"": 10.0,
      ""minimum_caption_duration"": 1.0,
      ""minimum_frames_between_captions"": 0
    }
  },
  ""event"": {
    ""event_uid"": ""54311c90-92ec-4069-9a54-0d7db575f4b5"",
    ""emitted_at"": ""2025-03-14T13:15:52.779Z"",
    ""event_name"": ""caption_set.workflow.approved"",
    ""webhook_api_url"": ""https://api.captionhub.com/api/v1/webhooks/981537""
  }
}";
    }
}
