using Dapper;

namespace DbTask.DataAccess.Commands.Tests
{
    public class RemoveTestsByIds : ICommand<long>
    {
        protected IEnumerable<long> Ids { get; private set; }

        public RemoveTestsByIds(IEnumerable<long> ids)
        {
            Ids = ids;
        }

        public long Execute()
        {
            using (var connection = Database.Instance.Connection)
            {
                connection.Open();

                return connection.Execute("DELETE FROM test WHERE id IN @Ids", new { Ids });
            }
        }
    }
}
