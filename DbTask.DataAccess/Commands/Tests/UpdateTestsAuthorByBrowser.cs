using System.Transactions;
using Dapper;
using DbTask.DataAccess.Models;

namespace DbTask.DataAccess.Commands.Tests
{
    public class UpdateWhereBrowserEqualsTo : ICommand
    {
        protected string Browser { get; private set; }
        protected long? AuthorId { get; private set; }

        public UpdateWhereBrowserEqualsTo(string browser, long? authorId)
        {
            Browser = browser;
            AuthorId = authorId;
        }

        public long Execute()
        {
            using (var connection = Database.Instance.Connection)
            {
                connection.Open();

                return connection.Execute(
                            "UPDATE test SET author_id = @AuthorId " +
                            "WHERE browser = @Browser",
                            new { AuthorId, Browser });
            }
        }
    }
}
