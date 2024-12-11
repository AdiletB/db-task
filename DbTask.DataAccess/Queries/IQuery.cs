using DbTask.DataAccess.Models;

namespace DbTask.DataAccess.Queries
{
    public interface IQuery<T> where T : Entity
    {
        public List<T> Execute();
    }
}
