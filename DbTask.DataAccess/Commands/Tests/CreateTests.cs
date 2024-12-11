﻿using System.Diagnostics;
using Dapper;
using DbTask.DataAccess.Models;

namespace DbTask.DataAccess.Commands.Tests
{
    public class CreateTests : ICommand<List<long>>
    {
        protected IEnumerable<Test> NewTests { get; private set; }

        public CreateTests(IEnumerable<Test> newTests)
        {
            NewTests = newTests;
        }

        public List<long> Execute()
        {
            var returnIds = new List<long>();

            using (var connection = Database.Instance.Connection)
            {
                connection.Open();

                foreach (var test in NewTests)
                {
                    try
                    {
                        long id = connection.QuerySingle<long>(
                            "INSERT INTO test(name, status_id, method_name, project_id, session_id, start_time, end_time, env, browser, author_id) " +
                            "OUTPUT INSERTED.id " +
                            "VALUES(@Name, @StatusId, @MethodName, @ProjectId, @SessionId, @StartTime, @EndTime, @Env, @Browser, @AuthorId)",
                        test);

                        returnIds.Add(id);
                    }
                    catch (Exception exc)
                    {
                        Debug.WriteLine(exc.Message);

                        continue;
                    }
                }
            }

            return returnIds;
        }
    }
}
