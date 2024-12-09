using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DbTask.DataAccess.Models
{
    public class Test
    {
        public long Id { get; set; }
        public string Name {  get; set; }
        public string MethodName { get; set; }
        public string? Browser {  get; set; }
        public long? AuthorId { get; set; }
        public long SessionId {  get; set; }
        public long ProjectId { get; set; }
        public int? StatusId { get; set; }
        public string Environment { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}
