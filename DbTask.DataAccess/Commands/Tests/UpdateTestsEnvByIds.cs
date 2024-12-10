using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DbTask.DataAccess.Models;

namespace DbTask.DataAccess.Commands.Tests
{
    public class UpdateTestsEnvByIds : ICommand<long>
    {
        protected string Env { get; private set; }
        protected IEnumerable<long> Ids { get; private set; }

        public UpdateTestsEnvByIds(string env, IEnumerable<long> ids)
        {
            Env = env;
            Ids = ids;
        }

        public long Execute()
        {
            using (var connection = Database.Instance.Connection)
            {
                connection.Open();

                return connection.Execute(
                            "UPDATE test SET env = @Env WHERE id IN @Ids",
                            new { Env, Ids });
            }
        }
    }
}
