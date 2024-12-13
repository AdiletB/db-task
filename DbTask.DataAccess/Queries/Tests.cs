using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbTask.DataAccess.Enums;
using DbTask.DataAccess.Models;

namespace DbTask.DataAccess.Queries
{
    public class Tests : Query
    {
        public List<Test> GetByBrowser(string browser)
        {
            return Read<Test>(QueryName.GetTestsByBrowser, new { browser });
        }

        public List<Test> GetByStatus(Status status)
        {
            return Read<Test>(QueryName.GetTestsByStatus, new { status });
        }

        public int Create(IEnumerable<Test> tests)
        {
            return Write(QueryName.CreateTests, tests);
        }

        public int Delete(IEnumerable<int> ids)
        {
            return Write(QueryName.RemoveTestsByIds, new { ids });
        }

        public int SetAuthor(int? authorId, string browser)
        {
            return Write(QueryName.SetTestsAuthorByBrowser, new { authorId, browser });
        }
    }
}
