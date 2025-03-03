using Apps.CaptionHub.Actions;
using Apps.CaptionHub.Models.Request.CaptionSet;
using Apps.CaptionHub.Models.Request.Project;
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
            { ProjectId = "BB_testing project including translation step", 
                LanguageCode = "CA-ES", 
                TranslationProvider="amazon" 
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


    }
}
