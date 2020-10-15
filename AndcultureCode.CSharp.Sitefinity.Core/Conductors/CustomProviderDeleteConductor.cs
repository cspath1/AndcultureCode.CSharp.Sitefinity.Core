using AndcultureCode.CSharp.Core.Interfaces;
using AndcultureCode.CSharp.Sitefinity.Core.Interfaces.Conductors;
using AndcultureCode.CSharp.Sitefinity.Core.Models.Entities;
using System;

namespace AndcultureCode.CSharp.Sitefinity.Core.Conductors
{
    public class CustomProviderDeleteConductor : CustomProviderConductorBase, ICustomProviderDeleteConductor
    {
        public virtual IResult<bool> Delete<T>(
            Guid  id,
            Guid? deletedById = null,
            bool  soft = true
        ) where T : DataItemEntity => getProvider().Delete<T>(id, deletedById, soft);

        public virtual IResult<bool> Delete<T>(
            T     item,
            Guid? deletedById = null,
            bool  soft = true
        ) where T : DataItemEntity => getProvider().Delete(item, deletedById, soft);

        public virtual IResult<bool> Restore<T>(Guid id) where T : DataItemEntity => getProvider().Restore<T>(id);

        public virtual IResult<bool> Restore<T>(T entity) where T : DataItemEntity => getProvider().Restore(entity);
    }
}
