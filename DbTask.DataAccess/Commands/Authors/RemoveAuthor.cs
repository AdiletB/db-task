using Dapper;

namespace DbTask.DataAccess.Commands.Authors
{
    public class RemoveAuthor : ICommand<long>
    {
        protected long AuthorId { get; private set; }

        public RemoveAuthor(long authorId)
        {
            AuthorId = authorId;
        }

        public long Execute()
        {
            using (var conection = Database.Instance.Connection)
            {
                conection.Open();

                return conection.Execute("DELETE FROM author WHERE id = @AuthorId", new { AuthorId });
            }
        }
    }
}
