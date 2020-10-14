using AndcultureCode.CSharp.Core.Interfaces;
using System;
using AndcultureCode.CSharp.Sitefinity.Core.Models.Entities;
using System.Collections.Generic;
using AndcultureCode.CSharp.Core.Interfaces.Conductors;

namespace AndcultureCode.CSharp.Sitefinity.Core.Interfaces.Conductors
{
    interface ICustomProviderCreateConductor : IConductor
    {
        /// <summary>
        /// Creates a single entity that's derived from the DataItemEntity abstract class.
        /// </summary>
        /// <typeparam name="T">The concrete subclass of the DataItemEntity abstract class.</typeparam>
        /// <param name="entity">The Entity.</param>
        /// <param name="createdById">The ID of the user creating the entity.</param>
        /// <returns></returns>
        IResult<T> Create<T>(
            T     entity, 
            Guid? createdById = null
        ) where T : DataItemEntity;

        /// <summary>
        /// Creates a list of entities that are derived from the DataItem.
        /// </summary>
        /// <typeparam name="T">The concrete subclass of the DataItemEntity abstract class.</typeparam>
        /// <param name="entities">The list of entities.</param>
        /// <param name="createdById">The ID of the user creating the entity.</param>
        /// <returns></returns>
        IResult<bool> Create<T>(
            IEnumerable<T> entities, 
            Guid?          createdById = null
        ) where T : DataItemEntity;
    }
}
