using AndcultureCode.CSharp.Core.Interfaces;
using AndcultureCode.CSharp.Core.Interfaces.Conductors;
using AndcultureCode.CSharp.Sitefinity.Core.Models.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace AndcultureCode.CSharp.Sitefinity.Core.Interfaces.Conductors
{
    interface ICustomProviderReadConductor : IConductor
    {
        /// <summary>
        /// Retrieves an entity by ID. Optionally takes a list of objects to include
        /// and attach to the record.
        /// </summary>
        /// <typeparam name="T">The concrete subclass of the DataItemEntity abstract class.</typeparam>
        /// <param name="id">The ID of the entity.</param>
        /// <param name="includes">An expression containing a list of objects/properties to include.</param>
        /// <returns></returns>
        IResult<T> FindById<T>(
            Guid                        id, 
            Expression<Func<T, object>> includes = null
        ) where T : DataItemEntity;

        /// <summary>
        /// Retrieves a list of entities. Optionally takes parameters to include/attach properties to
        /// each record, order the results, as well as a flag to filter by application name.
        /// </summary>
        /// <typeparam name="T">The concrete subclass of the DataItemEntity abstract class</typeparam>
        /// <param name="filter">Optional expression of filter criteria.</param>
        /// <param name="includes">Optional expression of objects/properties to include.</param>
        /// <param name="orderBy">Optional Order By function.</param>
        /// <param name="narrowApplication">Whether or not to filter by the current ApplicationName.</param>
        /// <returns></returns>
        IResult<IQueryable<T>> FindAll<T>(
            Expression<Func<T, bool>>                 filter            = null,
            Expression<Func<T, object>>               includes          = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy           = null,
            bool                                      narrowApplication = true
        ) where T : DataItemEntity;
    }
}
