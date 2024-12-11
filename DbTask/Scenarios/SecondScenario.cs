using DbTask.DataAccess.Commands.Projects;
using DbTask.DataAccess.Commands.Tests;
using DbTask.DataAccess.Models;
using DbTask.DataAccess.Queries.Tests;
using DbTask.Tests.Utils;

namespace DbTask.Tests.Scenarios
{
    public class SecondScenario : BaseTest
    {
        protected long NewProjectId { get; set; }
        protected List<long> TrackedTestsIds { get; set; }


        [OneTimeSetUp]
        public void CreateProject()
        {
            NewProjectId = new CreateProject(new() { Name = "newproj" }).Execute();
        }

        [OneTimeTearDown]
        public void DeleteEntities()
        {
            new RemoveTestsByIds(TrackedTestsIds).Execute();
            new RemoveProject(NewProjectId).Execute();
        }

        [Test]
        public void CopyChromeTests()
        {
            TrackedTestsIds = new CreateTests(DbUtils.GetTests("Chrome").Select(t =>
            {
                t.ProjectId = NewProjectId;
                t.AuthorId = NewAuthorId;
                return t;
            })).Execute();


            Assert.That(DbUtils.GetTestsByIds(TrackedTestsIds)
                               .All(t => t.AuthorId == NewAuthorId && t.ProjectId == NewProjectId));
        }

        [Test]
        public void UpdateTestsEnv()
        {
            string replaceEnv = "NewEnv";

            new UpdateTestsEnvByIds(replaceEnv, TrackedTestsIds).Execute();

            Assert.That(DbUtils.GetTestsByIds(TrackedTestsIds)
                               .All(t => t.Env == replaceEnv));
        }

        [Test]
        public void UpdateTestsStatus()
        {
            long skipped = new GetTestsByStatus(Status.SKIPPED).Execute().Count();
            long updated = new UpdateTestsStatus(Status.FAILED, Status.SKIPPED).Execute();

            Assert.That(skipped == updated);
        }
    }
}
