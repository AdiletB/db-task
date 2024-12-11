namespace DbTask.DataAccess.Models
{
    public class Test : Entity
    {
        public string Name { get; set; }
        public Status StatusId { get; set; }
        public string MethodName { get; set; }
        public long ProjectId { get; set; }
        public long SessionId { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string Env { get; set; }
        public string? Browser { get; set; }
        public long? AuthorId { get; set; }
    }
}
