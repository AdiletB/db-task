using DbTask.DataAccess.Commands.Authors;
using DbTask.DataAccess.Models;

namespace DbTask.Tests.CRUD_Scenarios
{
    public class BaseTest
    {
        protected long? NewAuthorId { get; set; }

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
            if (NewAuthorId != null)
                new RemoveAuthor((long)NewAuthorId).Execute();
        }
    }
}
