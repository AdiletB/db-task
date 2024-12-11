using DbTask.DataAccess.Commands.Authors;
using DbTask.DataAccess.Queries;

namespace DbTask.Tests.Scenarios
{
    public class BaseTest
    {
        protected int CreatedAuthorId { get; set; }
        protected Authors Authors { get; } = new();

        [OneTimeSetUp]
        public void CreateAuthor()
        {
            CreatedAuthorId = Authors.Create(new()
            {
                Email = "a@mail.com",
                Login = "Schmo",
                Name = "Joe"
            });
        }

        [OneTimeTearDown]
        public void DeleteAuthor()
        {
            //new RemoveAuthor(CreatedAuthorId).Execute();
            Authors.RemoveAuthor(CreatedAuthorId);
        }
    }
}
