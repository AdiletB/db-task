using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbTask.DataAccess.Commands.Authors;
using DbTask.DataAccess.Commands.Tests;
using DbTask.DataAccess.Models;
using DbTask.DataAccess.Queries.Tests;
using DbTask.Tests.Scenarios;
using DbTask.Tests.Utils;

namespace DbTask.Tests.Scenarios
{
    public class FirstScenario : BaseTest
    {
        [Test]
        public void UpdateAuthorForChromeTests()
        {
            //Track ids
            
            DbUtils.UpdateTestAuthors("Chrome", NewAuthorId);

            Assert.That(DbUtils.GetTests("Chrome").All(t => t.AuthorId == NewAuthorId));
        }

        [Test]
        public void CreateSafariTests()
        {
            var fireFoxTests = DbUtils.GetTests("FireFox");

            new CreateTests(
                fireFoxTests.Select(t =>
                {
                    t.Browser = "Safari";
                    return t;
                }
                )
            ).Execute();

            var safariTests = DbUtils.GetTests("Safari");

            Assert.That(safariTests.SequenceEqual(fireFoxTests, new TestComparer()));
        }

        [Test]
        public void SetSafariAuthorsToNull()
        {
            DbUtils.UpdateTestAuthors("Safari");

            Assert.That(DbUtils.GetTests("Safari").All(t => t.AuthorId == NewAuthorId));
        }

        [Test]
        public void DeleteSafariTests()
        {
            new RemoveTestsByIds(DbUtils.GetTests("Safari").Select(t => t.Id)).Execute();

            Assert.That(DbUtils.GetTests("Safari").Count == 0);
        }

        [OneTimeTearDown]
        public void SetChromeAuthorsToNull()
        {
            DbUtils.UpdateTestAuthors("Chrome");
        }
    }
}
