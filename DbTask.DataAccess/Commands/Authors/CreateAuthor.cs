using Dapper;
using DbTask.DataAccess.Models;

namespace DbTask.DataAccess.Commands.Authors
{
    public class CreateAuthor : ICommand
    {
        protected Author NewAuthor { get; set; }
        public CreateAuthor(Author newAuthor)
        {
            NewAuthor = newAuthor;
        }

        public long Execute()
        {
            using(var connection = Database.Instance.Connection)
            {
                connection.Open();

                return connection.QuerySingle<long>(
                    "INSERT INTO author(name, login, email) " +
                    "OUTPUT INSERTED.id " +
                    "VALUES(@Name, @Login, @Email)",
                    new
                    {
                        NewAuthor.Name,
                        NewAuthor.Login,
                        NewAuthor.Email
                    });
            }
        }
    }
}
