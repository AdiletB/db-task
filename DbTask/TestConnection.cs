using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbTask.DataAccess;

namespace DbTask.Tests
{
    internal class TestConnection
    {
        [Test]
        [Ignore("Has no related scenarios")]
        public void ShouldOpenAndCloseConnection()
        {
            Database.Instance.Connection.Open();
            Thread.Sleep(1000);
            Database.Instance.Connection.Close();
            Assert.Pass();
        }
    }
}
