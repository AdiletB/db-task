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
        
        public List<Test> GetByIds(List<int> ids)
        {
            return Read<Test>(QueryName.GetTestsByIds, ids);
        }

        public List<Test> GetByStatus(Status status)
        {
            return Read<Test>(QueryName.GetTestsByStatus, new { status });
        }

        public int Create(List<Test> tests)
        {
            return Write(QueryName.CreateTests, tests);
        }

        public List<int> Delete(List<int> ids)
        {
            //WRITE?
            return Read<int>(QueryName.RemoveTestsByIds, ids);
        }

        public List<int> SetAuthor(int? authorId, string browser)
        {
            //WRITE?
            return Read<int>(QueryName.SetTestsAuthorByBrowser, new { authorId, browser });
        }
    }
}
