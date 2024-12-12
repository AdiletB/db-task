﻿using FluentAssertions;

namespace DbTask.Tests.Scenarios
{
    using Tests = DataAccess.Queries.Tests;
    public class FirstScenario : BaseTest
    {
        protected Tests Tests { get; } = new();

        [Test, Order(1)]
        public void SetChromeTestsAuthor()
        {
            Tests.SetAuthor(CreatedAuthorId, "Chrome");

            var chromeTests = Tests.GetByBrowser("Chrome");

            chromeTests.Should().OnlyContain(t => t.AuthorId == CreatedAuthorId);
        }

        [Test, Order(2)]
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

        [Test, Order(3)]
        public void SetSafariTestsAuthor()
        {
            Tests.SetAuthor(null, "Safari");
            var safariTests = Tests.GetByBrowser("Safari");

            safariTests.Should().OnlyContain(t => t.AuthorId == null);
        }

        [Test, Order(4)]
        public void RemoveSafariTests()
        {
            var safariTests = Tests.GetByBrowser("Safari");

            int deleted = Tests.Delete(safariTests.Where(t => t.AuthorId is null)
                                                  .Select(t => t.Id)
                                                  .ToList());

            deleted.Should().Be(safariTests.Count);
        }

        [OneTimeTearDown]
        public void ResetChromeTestsAuthor()
        {
            Tests.SetAuthor(null, "Chrome");
        }
    }
}
