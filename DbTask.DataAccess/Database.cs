using Microsoft.Data.SqlClient;

namespace DbTask.DataAccess
{
    internal class Database
    {
        private string connectionString;

        private static Database instance;
        internal static Database Instance => instance ??= new Database();

        private Database()
        {
            connectionString = "Server=(local);Integrated Security=SSPI;Initial Catalog=testdb;TrustServerCertificate=True";
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;

        }

        internal SqlConnection Connection => new SqlConnection(connectionString);
    }
}
