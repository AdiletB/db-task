using DbTask.DataAccess.Models;

namespace DbTask.DataAccess.Commands
{
    public interface ICommand
    {
        public long Execute();
    }
}
