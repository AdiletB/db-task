using Dapper;
using DbTask.DataAccess.Models;

namespace DbTask.DataAccess.Queries.Tests
{
    public class GetTestsByBrowser : IQuery<Test>
    {
        protected string Browser { get; private set; }

        public GetTestsByBrowser(string browser)
        {
            Browser = browser;
        }

        public List<Test> Execute()
        {
            using (var connection = Database.Instance.Connection)
            {
                connection.Open();

                return connection.Query<Test>(
                    "SELECT * FROM test WHERE browser = @Browser", new { Browser })
                    .ToList();
            }
        }
    }
}
