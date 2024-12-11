namespace DbTask.DataAccess.Commands
{
    public interface ICommand<out T>
    {
        public T Execute();
    }
}
