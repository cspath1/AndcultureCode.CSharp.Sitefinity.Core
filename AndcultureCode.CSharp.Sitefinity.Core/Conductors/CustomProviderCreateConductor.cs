using AndcultureCode.CSharp.Core.Interfaces;
using AndcultureCode.CSharp.Sitefinity.Core.Interfaces.Conductors;
using AndcultureCode.CSharp.Sitefinity.Core.Models.Entities;
using System;
using System.Collections.Generic;

namespace AndcultureCode.CSharp.Sitefinity.Core.Conductors
{
    public class CustomProviderCreateConductor : CustomProviderConductorBase, ICustomProviderCreateConductor
    {
        public virtual IResult<T> Create<T>(
            T     entity,
            Guid? createdById = null
        ) where T : DataItemEntity => getProvider().Create(entity, createdById);

        public virtual IResult<IEnumerable<T>> Create<T>(
            IEnumerable<T> entities,
            Guid? createdById = null
        ) where T : DataItemEntity => getProvider().Create(entities, createdById);

    }
}
