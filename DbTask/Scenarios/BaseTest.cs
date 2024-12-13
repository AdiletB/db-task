using DbTask.DataAccess.Models;
using DbTask.DataAccess.Queries;
using DbTask.Tests.Utils;
using Newtonsoft.Json.Linq;

namespace DbTask.Tests.Scenarios
{
    public class BaseTest
    {
        protected int CreatedAuthorId { get; set; }
        protected Authors Authors { get; } = new();
        protected JsonFile TestData { get; } = new("test_data.json");

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
