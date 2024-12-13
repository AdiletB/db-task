using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

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
