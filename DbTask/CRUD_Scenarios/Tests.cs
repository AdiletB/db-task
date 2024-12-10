using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbTask.DataAccess.Commands.Authors;
using DbTask.DataAccess.Commands.Tests;
using DbTask.DataAccess.Queries.Tests;
using DbTask.Tests.CRUD_Scenarios;

namespace DbTask.Tests.Scenarios
{
    public class Tests : BaseTest
    {
        [Test]
        public void UpdateAuthorForChromeTests()
        {
            new UpdateAuthorWhereBrowserEqualsTo("Chrome", NewAuthorId).Execute();

            var chromeTests = new GetByBrowser("Chrome").Execute();
            
            Assert.That(chromeTests.All(t => t.AuthorId == NewAuthorId));
        }

        [OneTimeTearDown]
        public void SetAuthorsToNull()
        {
            new UpdateAuthorWhereBrowserEqualsTo("Chrome", null).Execute();
        }
    }
}
