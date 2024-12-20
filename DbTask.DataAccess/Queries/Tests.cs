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

        public int Remove(IEnumerable<int> ids)
        {
            return Write(QueryName.RemoveTestsByIds, new { ids });
        }

        public int SetAuthorByBrowser(int? authorId, string browser)
        {
            return Write(QueryName.SetTestsAuthorByBrowser, new { authorId, browser });
        }

        public int SetEnv(IEnumerable<int> ids, string env)
        {
            return Write(QueryName.SetTestsEnvByIds, new { ids, env });
        }

        public int SetStatus(IEnumerable<int> ids, Status status)
        {
            return Write(QueryName.SetTestsStatusByIds, new { ids, status });
        }
    }
}
