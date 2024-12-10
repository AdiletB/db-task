using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbTask.DataAccess.Commands.Authors;
using DbTask.DataAccess.Commands.Tests;
using DbTask.DataAccess.Models;
using DbTask.DataAccess.Queries.Tests;
using DbTask.Tests.CRUD_Scenarios;
using DbTask.Tests.Utils;

namespace DbTask.Tests.Scenarios
{
    public class Tests : BaseTest
    {
        [Test]
        public void UpdateAuthorForChromeTests()
        {
            UpdateTestAuthors("Chrome", NewAuthorId);

            Assert.That(GetTests("Chrome").All(t => t.AuthorId == NewAuthorId));
        }

        [Test]
        public void CreateSafariTests()
        {
            var fireFoxTests = GetTests("FireFox");

            new CreateTests(
                fireFoxTests.Select(t =>
                {
                    t.Browser = "Safari";
                    return t;
                }
                )
            ).Execute();

            var safariTests = GetTests("Safari");

            Assert.That(safariTests.SequenceEqual(fireFoxTests, new TestComparer()));
        }

        [Test]
        public void SetSafariAuthorsToNull()
        {
            UpdateTestAuthors("Safari");

            Assert.That(GetTests("Safari").All(t => t.AuthorId == NewAuthorId));
        }

        [Test]
        public void DeleteSafariTests()
        {
            new RemoveTests(GetTests("Safari").Select(t => t.Id)).Execute();

            Assert.That(GetTests("Safari").Count == 0);
        }

        [OneTimeTearDown]
        public void SetChromeAuthorsToNull()
        {
            if (NewAuthorId != null)
                UpdateTestAuthors("Chrome");
        }

        private List<Test> GetTests(string browser) => new GetByBrowser(browser).Execute();

        private void UpdateTestAuthors(string browser, long? authorId = null) 
            => new UpdateWhereBrowserEqualsTo(browser, authorId).Execute();
    }
}
