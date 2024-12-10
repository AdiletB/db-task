using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DbTask.DataAccess.Models;

namespace DbTask.DataAccess.Commands.Projects
{
    public class RemoveProject : ICommand<long>
    {
        protected long ProjectId { get; private set; }

        public RemoveProject(long projectId)
        {
            ProjectId = projectId;
        }

        public long Execute()
        {
            using (var conection = Database.Instance.Connection)
            {
                conection.Open();

                return conection.Execute("DELETE FROM project WHERE id = @ProjectId", new { ProjectId });
            }
        }
    }
}
