using System;

namespace AndcultureCode.CSharp.Sitefinity.Core.Interfaces.Entity
{
    public interface ICreatable
    {
        Guid?           CreatedById { get; set; }
        DateTimeOffset? CreatedOn   { get; set; }
    }
}
