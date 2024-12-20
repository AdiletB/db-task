using DbTask.DataAccess.Models;
using DbTask.DataAccess.Queries;
using DbTask.Tests.Utils;

namespace DbTask.Tests.Scenarios
{
    using Tests = DataAccess.Queries.Tests;
    public class BaseTest
    {
        protected int CreatedAuthorId { get; set; }
        protected Authors Authors { get; } = new();
        protected JsonFile TestData { get; } = new("test_data.json");
        protected Tests Tests { get; } = new();

        [OneTimeSetUp]
        public void CreateAuthor()
        {
            var newAuthor = TestData.Get<Author>("newAuthor");

            CreatedAuthorId = Authors.Create(newAuthor);
        }

        [OneTimeTearDown]
        public void RemoveAuthor()
        {
            Authors.RemoveAuthor(CreatedAuthorId);
        }
    }
}
