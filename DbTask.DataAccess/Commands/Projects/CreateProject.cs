using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DbTask.DataAccess.Models;

namespace DbTask.DataAccess.Commands.Projects
{
    public class CreateProject : ICommand<long>
    {
        protected Project NewProject { get; private set; }

        public CreateProject(Project newProject)
        {
            NewProject = newProject;
        }

        public long Execute()
        {
            using (var connection = Database.Instance.Connection)
            {
                connection.Open();

                return connection.QuerySingle<long>(
                    "INSERT INTO project(name) " +
                    "OUTPUT INSERTED.id " +
                    "VALUES(@Name)",
                    new
                    {
                        NewProject.Name
                    });
            }
        }
    }
}
