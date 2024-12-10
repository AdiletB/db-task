using DbTask.DataAccess.Commands.Authors;
using DbTask.DataAccess.Models;

namespace DbTask.Tests.Scenarios
{
    public class BaseTest
    {
        protected long NewAuthorId { get; set; }

        [OneTimeSetUp]
        public void CreateAuthor()
        {
            NewAuthorId = new CreateAuthor(
                new()
                {
                    Email = "a@mail.com",
                    Login = "Schmo",
                    Name = "Joe"
                }).Execute();
        }

        [OneTimeTearDown]
        public void DeleteAuthor()
        {
            new RemoveAuthor(NewAuthorId).Execute();
        }
    }
}
