using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbTask.DataAccess.Enums;
using DbTask.DataAccess.Models;

namespace DbTask.DataAccess.Queries
{
    public class Tests_ : Query
    {
        public List<Test> GetByBrowser(string browser)
        {
            return Execute<Test>(QueryName.GetTestsByBrowser, new { Browser = browser });
        }

    }
}
