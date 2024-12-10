using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DbTask.DataAccess.Models;

namespace DbTask.DataAccess.Commands.Tests
{
    public class CreateTests : ICommand
    {
        protected IEnumerable<Test> NewTests { get; private set; }

        public CreateTests(IEnumerable<Test> newTests)
        {
            NewTests = newTests;
        }

        public long Execute()
        {
            using(var connection = Database.Instance.Connection)
            {
                connection.Open();

                return connection.Execute(
                    "INSERT INTO test(name, status_id, method_name, project_id, session_id, start_time, end_time, env, browser, author_id)" +
                    "VALUES(@Name, @StatusId, @MethodName, @ProjectId, @SessionId, @StartTime, @EndTime, @Env, @Browser, @AuthorId)",
                    NewTests);
            }
        }
    }
}
