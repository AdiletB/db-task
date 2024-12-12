using DbTask.DataAccess.Enums;
using DbTask.DataAccess.Models;

namespace DbTask.DataAccess.Queries
{
    public class Authors : Query
    {
        public int Create(Author author)
        {
            return Read<int>(QueryName.CreateAuthor, author).First();
        }

        public void RemoveAuthor(int authorId)
        {
            Read<int>(QueryName.RemoveAuthorById, new { authorId });
        }
    }
}
