using Dapper;
using DbTask.DataAccess.Models;

namespace DbTask.DataAccess.Commands.Tests
{
    public class UpdateTestsStatus : ICommand<long>
    {
        protected Status New { get; private set; }
        protected Status Old { get; private set; }

        public UpdateTestsStatus(Status newStatus, Status oldStatus)
        {
            New = newStatus;
            Old = oldStatus;
        }

        public long Execute()
        {
            using (var connection = Database.Instance.Connection)
            {
                connection.Open();

                return connection.Execute(
                            "UPDATE test SET status_id = @New WHERE status_id = @Old",
                            new { New, Old });
            }
        }
    }
}
