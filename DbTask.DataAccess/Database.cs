using Microsoft.Data.SqlClient;

namespace DbTask.DataAccess
{
    internal class Database
    {
        private static Database instance;
        internal static Database Instance => instance ??= new Database();
        internal string ConnectionString { get; set; }

        private Database()
        {
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
        }

        internal SqlConnection Connection => new(ConnectionString);

        internal SqlConnection OpenConnection()
        {
            Connection.Open();

            return Connection;
        }
    }
}
