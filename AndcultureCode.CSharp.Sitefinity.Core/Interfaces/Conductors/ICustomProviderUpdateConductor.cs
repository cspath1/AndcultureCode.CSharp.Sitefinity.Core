using AndcultureCode.CSharp.Core.Interfaces;
using AndcultureCode.CSharp.Core.Interfaces.Conductors;
using AndcultureCode.CSharp.Sitefinity.Core.Models.Entities;
using System;
using System.Collections.Generic;

namespace AndcultureCode.CSharp.Sitefinity.Core.Interfaces.Conductors
{
    public interface ICustomProviderUpdateConductor : IConductor
    {
        /// <summary>
        /// Updates a single entity.
        /// </summary>
        /// <typeparam name="T">The concrete subclass of the DataItemEntity abstract class.</typeparam>
        /// <param name="item">The item being updated.</param>
        /// <param name="updatedById">The ID of the user updating the entity.</param>
        /// <returns></returns>
        IResult<bool> Update<T>(
            T     item, 
            Guid? updatedById = null
        ) where T : DataItemEntity;

        /// <summary>
        /// Updates a list of entities.
        /// </summary>
        /// <typeparam name="T">The concrete subclass of the DataItemEntity abstract class.</typeparam>
        /// <param name="items">The list of items being updates.</param>
        /// <param name="updatedById">The ID of the user updating the entity.</param>
        /// <returns></returns>
        IResult<bool> Update<T>(
            IEnumerable<T> items, 
            Guid?          updatedById = null
        ) where T : DataItemEntity;
    }
}
