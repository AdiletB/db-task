using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbTask.DataAccess.Enums;
using DbTask.DataAccess.Models;

namespace DbTask.DataAccess.Queries
{
    public class Projects : Query
    {
        public int Create(Project project)
        {
            return Execute<int>(QueryName.CreateProject, project).First();
        }
        public void Remove(int projectId)
        {
            Execute<int>(QueryName.RemoveProject, new { ProjectId = projectId });
        }
    }
}
