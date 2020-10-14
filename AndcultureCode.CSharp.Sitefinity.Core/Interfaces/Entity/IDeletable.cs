using System;

namespace AndcultureCode.CSharp.Sitefinity.Core.Interfaces.Entity
{
    public interface IDeletable
    {
        Guid?           DeletedById { get; set; }
        DateTimeOffset? DeletedOn   { get; set; }
    }
}
