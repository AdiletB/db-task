using DbTask.DataAccess;
using DbTask.Tests.Utils;

namespace DbTask.Tests
{
    [SetUpFixture]
    public class GlobalSetup
    {
        protected JsonFile Config { get; } = new("config.json");

        [OneTimeSetUp]
        public void Setup()
            => DbConfig.ConnectionString = Config.Get<string>("connectionString");
    }
}
