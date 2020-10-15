using AndcultureCode.CSharp.Core.Interfaces;
using AndcultureCode.CSharp.Sitefinity.Core.Interfaces.Conductors;
using AndcultureCode.CSharp.Sitefinity.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AndcultureCode.CSharp.Sitefinity.Core.Conductors
{
    public class CustomProviderConductor : CustomProviderConductorBase, ICustomProviderConductor
    {

        #region Properties

        /// <summary>
        /// Conductor property to create an entity or entities.
        /// </summary>
        protected readonly ICustomProviderCreateConductor _createConductor;

        /// <summary>
        /// Conductor property to delete or restore an entity or entities.
        /// </summary>
        protected readonly ICustomProviderDeleteConductor _deleteConductor;

        /// <summary>
        /// Conductor property to get an entity or entities.
        /// </summary>
        protected readonly ICustomProviderReadConductor   _readConductor;

        /// <summary>
        /// Conductor property to delete an entity or entities.
        /// </summary>
        protected readonly ICustomProviderUpdateConductor _updateConductor;

        #endregion Properties


        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="createConductor">The conductor instance that should be used to perform create operations.</param>
        /// <param name="deleteConductor">The conductor instance that should be used to perform delete operations.</param>
        /// <param name="readConductor">The conductor instance that should be used to perform read operations.</param>
        /// <param name="updateConductor">The conductor instance that should be used to perform delete operations.</param>
        public CustomProviderConductor(
            ICustomProviderCreateConductor createConductor,
            ICustomProviderDeleteConductor deleteConductor,
            ICustomProviderReadConductor   readConductor,
            ICustomProviderUpdateConductor updateConductor
        )
        {
            _createConductor = createConductor;
            _deleteConductor = deleteConductor;
            _readConductor   = readConductor;
            _updateConductor = updateConductor;
        }

        #endregion Constructor


        #region Public Methods

        #region Create

        public IResult<T> Create<T>(
            T     entity,
            Guid? createdById = null
        ) where T : DataItemEntity => _createConductor.Create(entity, createdById);

        public IResult<IEnumerable<T>> Create<T>(
            IEnumerable<T> entities,
            Guid?          createdById = null
        ) where T : DataItemEntity => _createConductor.Create(entities, createdById);

        #endregion Create


        #region Delete

        public IResult<bool> Delete<T>(
            Guid  id,
            Guid? deletedById = null,
            bool  soft = true
        ) where T : DataItemEntity => _deleteConductor.Delete<T>(id, deletedById, soft);

        public IResult<bool> Delete<T>(
            T     item,
            Guid? deletedById = null,
            bool  soft = true
        ) where T : DataItemEntity => _deleteConductor.Delete(item, deletedById, soft);

        public IResult<bool> Restore<T>(Guid id) where T : DataItemEntity => _deleteConductor.Restore<T>(id);

        public IResult<bool> Restore<T>(T entity) where T : DataItemEntity => _deleteConductor.Restore(entity);

        #endregion Delete


        #region Read

        public IResult<T> FindById<T>(
            Guid                        id,
            Expression<Func<T, object>> includes = null
        ) where T : DataItemEntity => _readConductor.FindById<T>(id, includes);

        public IResult<IQueryable<T>> FindAll<T>(
            Expression<Func<T, bool>>                 filter            = null,
            Expression<Func<T, object>>               includes          = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy           = null,
            bool                                      narrowApplication = true
        ) where T : DataItemEntity => _readConductor.FindAll(filter, includes, orderBy, narrowApplication);

        #endregion Read


        #region Update

        public IResult<bool> Update<T>(
            T     item,
            Guid? updatedById = null
        ) where T : DataItemEntity => _updateConductor.Update(item, updatedById);

        public IResult<bool> Update<T>(
            IEnumerable<T> items,
            Guid?          updatedById = null
        ) where T : DataItemEntity => _updateConductor.Update(items, updatedById);

        #endregion Update

            #endregion Public Methods

    }
}
