using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbTask.DataAccess.Commands.Tests;
using DbTask.DataAccess.Models;
using DbTask.DataAccess.Queries.Tests;

namespace DbTask.Tests.Utils
{
    public class DbUtils
    {
        public static List<Test> GetTests(string browser) => new GetTestsByBrowser(browser).Execute();

        public static void UpdateTestAuthors(string browser, long? authorId = null)
            => new UpdateTestsAuthorByBrowser(browser, authorId).Execute();
    }
}
