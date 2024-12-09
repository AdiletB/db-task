using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DbTask.DataAccess.Models;
using Microsoft.Data.SqlClient;

namespace DbTask.DataAccess
{
    public class Database
    {
        private string connectionString;

        private static Database instance;
        public static Database Instance => instance ??= new Database();

        private Database()
        {
            connectionString = "Server=(local);Integrated Security=SSPI;Initial Catalog=testdb;TrustServerCertificate=True";
        }

        public SqlConnection Connection => new SqlConnection(connectionString);
    }
}
