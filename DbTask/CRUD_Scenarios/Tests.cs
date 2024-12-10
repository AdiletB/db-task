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

            var chromeTests = GetTests("Chrome");

            Assert.That(chromeTests.All(t => t.AuthorId == NewAuthorId));
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
                ).ToList()
            ).Execute();

            var safariTests = GetTests("Safari");

            Assert.That(safariTests.SequenceEqual(fireFoxTests, new TestComparer()));
        }

        [Test]
        public void SetSafariAuthorsToNull()
        {
            int all = GetTests("Safari").Count;
            long updated = UpdateTestAuthors("Safari");

            Assert.That(updated == all);
        }

        [OneTimeTearDown]
        public void SetChromeAuthorsToNull()
        {
            if (NewAuthorId != null)
                UpdateTestAuthors("Chrome");
        }

        private List<Test> GetTests(string browser) => new GetByBrowser("Safari").Execute();

        private long UpdateTestAuthors(string browser, long? authorId = null) 
            => new UpdateAuthorWhereBrowserEqualsTo(browser, authorId).Execute();
    }
}
