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
    public interface ICustomProviderDeleteConductor : IConductor
    {
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
            bool  soft        = true
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
            bool  soft        = true
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
    }
}
