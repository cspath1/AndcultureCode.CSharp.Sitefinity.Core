using AndcultureCode.CSharp.Core;
using AndcultureCode.CSharp.Core.Extensions;
using AndcultureCode.CSharp.Core.Interfaces;
using AndcultureCode.CSharp.Sitefinity.Core.Interfaces.Entity;
using AndcultureCode.CSharp.Sitefinity.Core.Interfaces.Providers;
using AndcultureCode.CSharp.Sitefinity.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Telerik.OpenAccess;
using Telerik.Sitefinity.Data;
using Telerik.Sitefinity.Modules.GenericContent.Data;
using Telerik.Sitefinity.Modules.Pages.Data;

namespace AndcultureCode.CSharp.Sitefinity.Core.Providers
{

    [ContentProviderDecorator(typeof(OpenAccessContentDecorator))]
    public class CustomPageProvider : OpenAccessPageProvider, ICustomPageProvider
    {

        #region ICustomPageProvider Implementation

        public virtual IResult<T> Create<T>(
            T     entity, 
            Guid? createdById = null
        ) where T : DataItemEntity => Do<T>.Try(r =>
        {
            if (entity.Id == Guid.Empty)
            {
                entity.Id = GetNewGuid();
            }

            if (string.IsNullOrWhiteSpace(entity.ApplicationName))
            {
                entity.ApplicationName = this.ApplicationName;
            }

            entity.Provider = this;

            if (entity is ICreatable)
            {
                if (createdById.HasValue)
                {
                    ((ICreatable)entity).CreatedById = createdById;
                }
                ((ICreatable)entity).CreatedOn = DateTimeOffset.UtcNow;
            }

            this.GetContext().Add(entity);
            SaveChanges();

            return entity;
        }).Result;

        public virtual IResult<IEnumerable<T>> Create<T>(
            IEnumerable<T> entities, 
            Guid?          createdById = null
        ) where T : DataItemEntity => Do<IEnumerable<T>>.Try(r =>
        {
            var created = new List<T>();

            var numInserted = 0;

            foreach (var entity in entities)
            {
                if (entity.Id == Guid.Empty)
                {
                    entity.Id = GetNewGuid();
                }

                if (string.IsNullOrWhiteSpace(entity.ApplicationName))
                {
                    entity.ApplicationName = this.ApplicationName;
                }

                entity.Provider = this;

                if (entity is ICreatable)
                {
                    if (createdById.HasValue)
                    {
                        ((ICreatable)entity).CreatedById = createdById;
                    }
                    ((ICreatable)entity).CreatedOn = DateTimeOffset.UtcNow;
                }

                this.GetContext().Add(entity);
                created.Add(entity);

                if (++numInserted >= 100)
                {
                    numInserted = 0;
                    SaveChanges();
                }
            }

            // Save whatever is left over
            SaveChanges();

            return created;
        }).Result;

        public virtual IResult<bool> Delete<T>(
            Guid  id,
            Guid? deletedById = null,
            bool  soft        = true
        ) where T : DataItemEntity => Do<bool>.Try(r =>
        {
            var findResult = FindById<T>(id);

            if (findResult.HasErrors)
            {
                r.AddErrors(findResult.Errors);
            }

            return Delete(findResult.ResultObject, deletedById, soft).ResultObject;
        }).Result;

        public virtual IResult<bool> Delete<T>(
            T     item, 
            Guid? deletedById = null, 
            bool  soft        = true
        ) where T : DataItemEntity => Do<bool>.Try(r =>
        {
            if (item == null)
            {
                r.AddError(
                    "Delete",
                    $"{item.GetType()} does not exist."
                );
                return false;
            }

            if (soft && !(item is IDeletable))
            {
                r.AddError(
                    "Delete",
                    "In order to perform a soft delete, the object must implement the IDeletable interface."
                );
                return false;
            }

            if (soft)
            {
                if (deletedById.HasValue)
                {
                    ((IDeletable)item).DeletedById = deletedById;
                }

                ((IDeletable)item).DeletedOn = DateTimeOffset.UtcNow;
            }
            else
            {
                this.GetContext().Remove(item);
            }

            SaveChanges();
            return true;
        }).Result;

        public virtual IResult<IQueryable<T>> FindAll<T>(
            Expression<Func<T, bool>>                 filter            = null,
            Expression<Func<T, object>>               includes          = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy           = null,
            bool                                      narrowApplication = true
        ) where T : DataItemEntity => Do<IQueryable<T>>.Try(r =>
        {
            var queryable = this.GetContext().GetAll<T>();

            if (narrowApplication)
            {
                queryable = queryable.Where(e => e.ApplicationName == ApplicationName);
            }

            if (filter != null)
            {
                queryable = queryable.Where(filter);
            }

            if (orderBy != null)
            {
                queryable = orderBy(queryable);
            }

            if (includes != null)
            {
                queryable = queryable.Include(includes);
            }

            return queryable;
        }).Result;

        public virtual IResult<T> FindById<T>(
            Guid                        id,
            Expression<Func<T, object>> includes = null
        ) where T : DataItemEntity => Do<T>.Try(r =>
        {
            if (id == Guid.Empty)
                throw new ArgumentException("Id cannot be an Empty Guid");

            var queryable = this.GetContext().GetAll<T>().Where(e => e.Id == id);

            if (includes != null)
            {
                queryable = queryable.Include(includes);
            }

            return queryable.FirstOrDefault();
        }).Result;

        public virtual IResult<bool> Restore<T>(Guid id) where T : DataItemEntity => Do<bool>.Try(r =>
        {
            var findResult = FindById<T>(id);
            if (findResult.HasErrors)
            {
                r.AddErrors(findResult.Errors);
                return false;
            }

            var restoreResult = Restore(findResult.ResultObject);
            if (restoreResult.HasErrors)
            {
                r.AddErrors(restoreResult.Errors);
                return false;
            }

            return true;
        }).Result;

        public virtual IResult<bool> Restore<T>(T entity) where T : DataItemEntity => Do<bool>.Try(r =>
        {
            if (entity == null)
            {
                r.AddError(
                    "Restore",
                    $"{entity.GetType()} does not exist."
                );
                return false;
            }

            if (!(entity is IDeletable))
            {
                r.AddError(
                    "Restore",
                    "In order to perform a soft delete restore, the object must implement the IDeletable interface."
                );
                return false;
            }

            ((IDeletable)entity).DeletedById = null;
            ((IDeletable)entity).DeletedOn   = null;

            SaveChanges();
            return true;
        }).Result;

        public virtual IResult<bool> Update<T>(T item, Guid? updatedById = null) where T : DataItemEntity => Do<bool>.Try(r =>
        {
            if (item is IUpdatable)
            {
                ((IUpdatable)item).UpdatedById = updatedById;
                ((IUpdatable)item).UpdatedOn   = DateTimeOffset.UtcNow;
            }

            SaveChanges();

            return true;
        }).Result;

        public virtual IResult<bool> Update<T>(IEnumerable<T> items, Guid? updatedById = null) where T : DataItemEntity => Do<bool>.Try(r =>
        {
            var numUpdated = 0;

            foreach (var entity in items)
            {
                if (entity is IUpdatable)
                {
                    ((IUpdatable)entity).UpdatedById = updatedById;
                    ((IUpdatable)entity).UpdatedOn = DateTimeOffset.UtcNow;
                }

                // Save in batches of 100, if there are at least 100 entities.
                if (++numUpdated >= 100)
                {
                    numUpdated = 0;

                    SaveChanges();
                }
            }

            return true;
        }).Result;

        #endregion ICustomPageProvider Implementation

        public virtual void SaveChanges() => this.GetContext().SaveChanges();

    }
}
