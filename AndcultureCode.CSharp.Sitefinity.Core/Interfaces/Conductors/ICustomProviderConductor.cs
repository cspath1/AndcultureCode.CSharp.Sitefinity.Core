using AndcultureCode.CSharp.Core.Interfaces;
using AndcultureCode.CSharp.Core.Interfaces.Conductors;
using AndcultureCode.CSharp.Sitefinity.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndcultureCode.CSharp.Sitefinity.Core.Interfaces.Conductors
{
    public interface ICustomProviderConductor : IConductor,
        ICustomProviderCreateConductor,
        ICustomProviderDeleteConductor,
        ICustomProviderReadConductor,
        ICustomProviderUpdateConductor
    {
        /// <summary>
        /// Automatically determines whether to create or update the supplied entity.
        /// </summary>
        /// <typeparam name="T">The concrete subclass of the DataItemEntity abstract class.</typeparam>
        /// <param name="item">The Entity.</param>
        /// <param name="createdOrUpdatedById">The ID of the user creating/updating the entity.</param>
        /// <returns></returns>
        IResult<T> CreateOrUpdate<T>(
            T     item, 
            Guid? createdOrUpdatedById = null
        ) where T : DataItemEntity;

        /// <summary>
        /// Automatically determines whether to create or update each individual entity in the supplied list.
        /// </summary>
        /// <typeparam name="T">The concrete subclass of the DataItemEntity abstract class.</typeparam>
        /// <param name="items">The list of Entities.</param>
        /// <param name="createdOrUpdatedById">The ID of the user creating/updating the entities.</param>
        /// <returns></returns>
        IResult<IEnumerable<T>> CreateOrUpdate<T>(
            IEnumerable<T> items, 
            Guid?          createdOrUpdatedById = null
        ) where T : DataItemEntity;
    }
}
