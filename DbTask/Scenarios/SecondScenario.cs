using DbTask.DataAccess.Enums;
using DbTask.DataAccess.Models;
using DbTask.DataAccess.Queries;
using FluentAssertions;

namespace DbTask.Tests.Scenarios
{
    public class SecondScenario : BaseTest
    {
        protected int CreatedProjectId { get; set; }
        protected List<int> TrackedTestIds { get; set; }
        protected Projects Projects { get; } = new();

        [OneTimeSetUp]
        public void CreateProject()
        {
            var newProject = TestData.Get<Project>("newProject");
            CreatedProjectId = Projects.Create(newProject);
        }

        [Test, Order(1)]
        public void CreateTests()
        {
            var expectedTests = Tests.GetByBrowser("Chrome")
                                .Select(t =>
                                {
                                    t.ProjectId = CreatedProjectId;
                                    t.AuthorId = CreatedAuthorId;
                                    return t;
                                }).ToList();

            Tests.Create(expectedTests);

            var chromeTests = Tests.GetByBrowser("Chrome")
                                   .Where(t => t.ProjectId == CreatedProjectId &&
                                               t.AuthorId == CreatedAuthorId)
                                   .ToList();

            chromeTests.Should().BeEquivalentTo(expectedTests, options =>
                           options.Excluding(test => test.Id));

            TrackedTestIds = chromeTests.Select(t => t.Id).ToList();
        }

        [Test, Order(2)]
        public void SetEnvForCreatedTests()
        {
            string expectedEnv = TestData.Get<string>("newEnv");

            int updated = Tests.SetEnv(TrackedTestIds, expectedEnv);

            updated.Should().Be(TrackedTestIds.Count);
        }

        [Test, Order(3)]
        public void SetSkippedTestsStatusToFailed()
        {

            var skippedTestsIds = Tests.GetByStatus(Status.SKIPPED)
                                       .Select(t => t.Id)
                                       .ToList();
            int updated = Tests.SetStatus(skippedTestsIds, Status.FAILED);
            updated.Should().Be(skippedTestsIds.Count);
        }

        [OneTimeTearDown]
        public void RemoveProjectAndTests()
        {
            Projects.Remove(CreatedProjectId);
            Tests.Remove(TrackedTestIds);
        }
    }
}
