using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace DbTask.DataAccess.Commands.Authors
{
    public class RemoveAuthorById : ICommand
    {
        public long AuthorId { get; set; }

        public RemoveAuthorById(long authorId)
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
