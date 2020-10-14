using System;

namespace AndcultureCode.CSharp.Sitefinity.Core.Interfaces.Entity
{
    public interface IUpdatable
    {
        Guid?           UpdatedById { get; set; }
        DateTimeOffset? UpdatedOn   { get; set; }
    }
}
