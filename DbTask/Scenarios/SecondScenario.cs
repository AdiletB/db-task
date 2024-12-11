using DbTask.DataAccess.Commands.Projects;
using DbTask.DataAccess.Commands.Tests;
using DbTask.DataAccess.Models;
using DbTask.DataAccess.Queries;
using DbTask.DataAccess.Queries.Tests;
using DbTask.Tests.Utils;

namespace DbTask.Tests.Scenarios
{
    public class SecondScenario : BaseTest
    {
        protected int NewProjectId { get; set; }
        protected List<long> TrackedTestsIds { get; set; }

        protected Projects Projects { get; } = new();


        [OneTimeSetUp]
        public void CreateProject()
        {
            NewProjectId = Projects.Create(new() { Name = "newproj" });
        }

        [OneTimeTearDown]
        public void DeleteEntities()
        {
            new RemoveTestsByIds(TrackedTestsIds).Execute();
            
            Projects.Remove(NewProjectId);
        }

        [Test]
        public void CopyChromeTests()
        {
            TrackedTestsIds = new CreateTests(DbUtils.GetTests("Chrome").Select(t =>
            {
                t.ProjectId = NewProjectId;
                t.AuthorId = CreatedAuthorId;
                return t;
            })).Execute();


            Assert.That(DbUtils.GetTestsByIds(TrackedTestsIds)
                               .All(t => t.AuthorId == CreatedAuthorId && t.ProjectId == NewProjectId));
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
