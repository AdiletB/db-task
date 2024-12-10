using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace DbTask.DataAccess.Commands.Tests
{
    public class RemoveTests : ICommand<long>
    {
        protected IEnumerable<long> Ids { get; private set; }

        public RemoveTests(IEnumerable<long> ids)
        {
            Ids = ids;
        }

        public long Execute()
        {
            using (var connection = Database.Instance.Connection)
            {
                connection.Open();

                return connection.Execute("DELETE FROM test WHERE id IN @Ids", new { Ids });
            }
        }
    }
}
