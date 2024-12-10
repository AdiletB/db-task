using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DbTask.DataAccess.Models;

namespace DbTask.DataAccess.Queries.Tests
{
    public class GetTestsByStatus : IQuery<Test>
    {
        protected Status Status { get; private set; }

        public GetTestsByStatus(Status statusId)
        {
            Status = statusId;
        }

        public List<Test> Execute()
        {
            using (var connection = Database.Instance.Connection)
            {
                connection.Open();

                return connection.Query<Test>(
                    "SELECT * FROM test WHERE status_id = @Status", new { Status })
                    .ToList();
            }
        }
    }
}
