using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DbTask.DataAccess.Enums;
using Microsoft.Data.SqlClient;

namespace DbTask.DataAccess.Queries
{
    public abstract class Query
    {
        protected Query() { }
        
        protected List<T> Execute<T>(QueryName queryName, object? parameters = null)
        {
            string sql = File.ReadAllText(@$"SQL\{queryName}.sql");

            using var connection = Database.Instance.Connection;
            connection.Open();

            return connection.Query<T>(sql, parameters).ToList();
        }
    }
}
