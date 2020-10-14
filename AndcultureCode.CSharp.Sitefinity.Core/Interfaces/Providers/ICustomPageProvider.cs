using AndcultureCode.CSharp.Core.Interfaces;
using AndcultureCode.CSharp.Sitefinity.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AndcultureCode.CSharp.Sitefinity.Core.Interfaces.Providers
{
    public interface ICustomPageProvider
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

        /// <summary>
        /// Deletes a single entity. Note that soft deleting an entity will
        /// mark it as deleted and mark who deleted it (if the item inherits from IDeletable), while standard deleting
        /// removes the entity entirely.
        /// </summary>
        /// <typeparam name="T">The concrete subclass of the DataItemEntity abstract class.</typeparam>
        /// <param name="id">The Entity ID.</param>
        /// <param name="deletedById">The ID of the user deleting the entity.</param>
        /// <param name="soft">Whether or not the deletion is a soft deletion.</param>
        /// <returns></returns>
        IResult<bool> Delete<T>(
            Guid  id,
            Guid? deletedById = null,
            bool  soft = true
        ) where T : DataItemEntity;

        /// <summary>
        /// Deletes a single entity. Note that soft deleting an entity will
        /// mark it as deleted and mark who deleted it (if the item inherits from IDeletable), while standard deleting
        /// removes the entity entirely.
        /// </summary>
        /// <typeparam name="T">The concrete subclass of the DataItemEntity abstract class.</typeparam>
        /// <param name="item">The item.</param>
        /// <param name="deletedById">The ID of the user deleting the entity.</param>
        /// <param name="soft">Whether or not the deletion is a soft deletion.</param>
        /// <returns></returns>
        IResult<bool> Delete<T>(
            T     item,
            Guid? deletedById = null,
            bool  soft = true
        ) where T : DataItemEntity;

        /// <summary>
        /// Deletes a list of entities. Note that soft deleting an entity will
        /// mark it as deleted and mark who deleted it (if the item inherits from IDeletable), while standard deleting
        /// removes the entity entirely.
        /// </summary>
        /// <typeparam name="T">The concrete subclass of the DataItemEntity abstract class.</typeparam>
        /// <param name="items">The list of items</param>
        /// <param name="deletedById">The ID of the user deleting the entities.</param>
        /// <param name="soft">Whether or not the deletion is a soft deletion.</param>
        /// <returns></returns>
        IResult<bool> Delete<T>(
            IEnumerable<T> items,
            Guid?          deletedById = null,
            bool           soft        = true
        ) where T : DataItemEntity;

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

        /// <summary>
        /// Restores a soft-deleted entity by clearing the DeletedOn and DeletedById fields.
        /// </summary>
        /// <typeparam name="T">The concrete subclass of the DataItemEntity abstract class.</typeparam>
        /// <param name="id">The ID of the item being restored.</param>
        /// <returns></returns>
        IResult<bool> Restore<T>(Guid id) where T : DataItemEntity;

        /// <summary>
        /// Restores a soft-deleted entity by clearing the DeletedOn and DeletedById fields.
        /// </summary>
        /// <typeparam name="T">The concrete subclass of the DataItemEntity abstract class.</typeparam>
        /// <param name="entity">The entity being restored.</param>
        /// <returns></returns>
        IResult<bool> Restore<T>(T entity) where T : DataItemEntity;

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
