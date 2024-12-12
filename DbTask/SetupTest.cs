using DbTask.DataAccess;

namespace DbTask.Tests
{
    [SetUpFixture]
    public class SetupTest
    {
        [OneTimeSetUp]
        public void Setup()
        {
            DbConfig.ConnectionString = Config.Get("connectionString");
        }
    }
}
