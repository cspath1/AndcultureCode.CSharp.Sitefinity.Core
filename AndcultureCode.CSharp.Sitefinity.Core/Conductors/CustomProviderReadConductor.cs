using AndcultureCode.CSharp.Core.Interfaces;
using AndcultureCode.CSharp.Sitefinity.Core.Interfaces.Conductors;
using AndcultureCode.CSharp.Sitefinity.Core.Models.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace AndcultureCode.CSharp.Sitefinity.Core.Conductors
{
    public class CustomProviderReadConductor : CustomProviderConductorBase, ICustomProviderReadConductor
    {
        public virtual IResult<IQueryable<T>> FindAll<T>(
            Expression<Func<T, bool>>                 filter            = null,
            Expression<Func<T, object>>               includes          = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy           = null,
            bool                                      narrowApplication = true
        ) where T : DataItemEntity => getProvider().FindAll(filter, includes, orderBy, narrowApplication);

        public virtual IResult<T> FindById<T>(
            Guid id,
            Expression<Func<T, object>> includes = null
        ) where T : DataItemEntity => getProvider().FindById<T>(id, includes);
    }
}
