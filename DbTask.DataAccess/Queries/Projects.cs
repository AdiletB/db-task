using DbTask.DataAccess.Enums;
using DbTask.DataAccess.Models;

namespace DbTask.DataAccess.Queries
{
    public class Projects : Query
    {
        public int Create(Project project)
        {
            return Read<int>(QueryName.CreateProject, project).First();
        }
        public void Remove(int projectId)
        {
            Read<int>(QueryName.RemoveProjectById, new { projectId });
        }
    }
}
