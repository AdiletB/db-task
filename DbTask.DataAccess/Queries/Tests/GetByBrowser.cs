using Dapper;
using DbTask.DataAccess.Models;

namespace DbTask.DataAccess.Queries.Tests
{
    public class GetByBrowser : IQuery<Test>
    {
        protected string Browser { get; private set; }

        public GetByBrowser(string browser)
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
