using DbTask.DataAccess.Commands.Projects;
using DbTask.DataAccess.Commands.Tests;
using DbTask.DataAccess.Queries.Tests;
using DbTask.Tests.Utils;

namespace DbTask.Tests.Scenarios
{
    public class SecondScenario : BaseTest
    {
        protected long? NewProjectId { get; set; }
        protected List<long> NewTestIds { get; set; }


        [OneTimeSetUp]
        public void CreateProject()
        {
            NewProjectId = new CreateProject(new() { Name = "newproj" }).Execute();
        }
        [OneTimeTearDown]
        public void DeleteEntities()
        {

        }
        [Test]
        public void CopyChromeTests()
        {
            NewTestIds = new CreateTests(DbUtils.GetTests("Chrome").Select(t =>
            {
                t.ProjectId = (long)NewProjectId!;
                t.AuthorId = NewAuthorId;
                return t;
            })).Execute();

            var newTests = new GetTestsByIds(NewTestIds).Execute();

            Assert.That(newTests.All(t => t.AuthorId == NewAuthorId && t.ProjectId == NewProjectId));
        }
    }
}
