using DbTask.DataAccess.Models;

namespace DbTask.Tests.CRUD_Scenarios
{
    public class BaseTest
    {
        protected List<Entity> Entities { get; } = new List<Entity>();
        protected long NewAuthorId { get; private set; }

        [OneTimeSetUp]
        public void CreateAuthor()
        {
        
        }

        [OneTimeTearDown]
        public void DeleteEntities()
        {

        }
    }
}
