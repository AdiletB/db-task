using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DbTask.DataAccess.Models
{
    public class Test : Entity
    {
        public string Name {  get; set; }
        public int StatusId { get; set; }
        public string MethodName { get; set; }
        public long ProjectId { get; set; }
        public long SessionId {  get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string Env { get; set; }
        public string? Browser {  get; set; }
        public long? AuthorId { get; set; }

        public override bool Equals(object? obj)
        {
            var other = obj as Test;
            if (other == null) return false;

            // :(
            return Name == other.Name
                   && StatusId == other.StatusId
                   && MethodName == other.MethodName
                   && ProjectId == other.ProjectId
                   && SessionId == other.SessionId
                   && StartTime == other.StartTime
                   && EndTime == other.EndTime
                   && Env == other.Env
                   && AuthorId == other.AuthorId;
        }
    }
}
