using System.Diagnostics.CodeAnalysis;
using DbTask.DataAccess.Models;

namespace DbTask.Tests.Utils
{
    internal class TestComparer : IEqualityComparer<Test>
    {
        public bool Equals(Test? x, Test? y)
        {
            return x.Name == y.Name
                   && x.StatusId == y.StatusId
                   && x.MethodName == y.MethodName
                   && x.ProjectId == y.ProjectId
                   && x.SessionId == y.SessionId
                   && x.StartTime == y.StartTime
                   && x.EndTime == y.EndTime
                   && x.Env == y.Env
                   && x.AuthorId == y.AuthorId;
        }

        public int GetHashCode([DisallowNull] Test obj)
        {
            throw new NotImplementedException();
        }
    }
}
