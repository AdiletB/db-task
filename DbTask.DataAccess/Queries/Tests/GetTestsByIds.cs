using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DbTask.DataAccess.Models;

namespace DbTask.DataAccess.Queries.Tests
{
    public class GetTestsByIds : IQuery<Test>
    {
        protected List<long> Ids { get; private set; }

        public GetTestsByIds(List<long> ids)
        {
            Ids = ids;
        }

        public List<Test> Execute()
        {
            using (var connection = Database.Instance.Connection)
            {
                connection.Open();

                return connection.Query<Test>(
                    "SELECT * FROM test WHERE id IN @Ids", new { Ids })
                    .ToList();
            }
        }
    }
}
