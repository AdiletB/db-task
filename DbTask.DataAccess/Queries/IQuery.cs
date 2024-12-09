using DbTask.DataAccess.Models;
using System.Collections.Generic;

namespace DbTask.DataAccess.Queries
{
    public interface IQuery<T> where T : Entity
    {
        public List<T> Execute();
    }
}
