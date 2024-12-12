using DbTask.DataAccess.Queries;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbTask.Tests.Scenarios
{
    public class FirstScenario : BaseTest
    {
        protected DataAccess.Queries.Tests Tests { get; } = new();
        protected List<int> TrackedTests { get; private set; }


        [OneTimeTearDown]
        public void ResetChromeTestsAuthor()
        {
            Tests.SetAuthor(null, "Chrome");
        }

        [Test]
        public void SetChromeTestsAuthor()
        {
            Tests.SetAuthor(CreatedAuthorId, "Chrome");

            Assert.That(Tests.GetByBrowser("Chrome").All(t => t.AuthorId == CreatedAuthorId));
        }

        [Test]
        public void CreateSafariTests()
        {
            var firefoxTests = Tests.GetByBrowser("Firefox");
            
            Tests.Create(
                firefoxTests.Select(t =>
                {
                    t.Browser = "Safari";
                    return t;
                }).ToList()
            );

            var safariTests = Tests.GetByBrowser("Safari");

            safariTests.Should().BeEquivalentTo(firefoxTests, options =>
                options.Excluding(test => test.Id));
        }
    }
}
