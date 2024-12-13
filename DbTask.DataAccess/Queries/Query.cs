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
        
        protected List<T> Read<T>(QueryName queryName, object? parameters = null)
        {
            using var connection = Database.Instance.OpenConnection();
            return connection.Query<T>(GetSql(queryName), parameters).ToList();
        }

        protected int Write(QueryName queryName, object? parameters = null)
        {
            using var connection = Database.Instance.OpenConnection();
            return connection.Execute(GetSql(queryName), parameters);
        }

        private string GetSql(QueryName queryName)
            => File.ReadAllText(@$"SQL\{queryName}.sql");
    }
}
