using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbTask.DataAccess.Queries.Tests;
using DbTask.Tests.CRUD_Scenarios;

namespace DbTask.Tests.Scenarios
{
    public class Tests : BaseTest
    {
        [Test]
        public void UpdateAuthorForChromeTests()
        {
            var chromeTests = new GetByBrowser("Chrome").Execute();
            Assert.That(chromeTests.Count(), Is.GreaterThan(0));
        }
    }
}
