namespace DbTask.DataAccess
{
    public static class DbConfig
    {
        public static string ConnectionString
        {
            get => Database.Instance.ConnectionString;
            set => Database.Instance.ConnectionString = value;
        }
    }
}
