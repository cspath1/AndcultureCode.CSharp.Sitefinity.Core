using AndcultureCode.CSharp.Sitefinity.Core.Interfaces.Entity;
using AndcultureCode.CSharp.Sitefinity.Core.Models.Entities;
using System;

namespace AndcultureCode.CSharp.Sitefinity.Core.Models
{
    public abstract class Auditable : DataItemEntity, IAuditable
    {

        #region IAuditable Implementation

        /// <summary>
        /// The identifier of the user who created the record
        /// </summary>
        public Guid?           CreatedById { get; set; }

        /// <summary>
        /// The date and time of the record creation
        /// </summary>
        public DateTimeOffset? CreatedOn { get; set; }

        /// <summary>
        /// The identifier of the user who performed the Delete
        /// </summary>
        public Guid?           DeletedById { get; set; }

        /// <summary>
        /// The date and time of the record deletion
        /// </summary>
        public DateTimeOffset? DeletedOn { get; set; }

        /// <summary>
        /// The identifier of the user who performed the Update
        /// </summary>
        public Guid?           UpdatedById { get; set; }

        /// <summary>
        /// The date and time of the record update
        /// </summary>
        public DateTimeOffset? UpdatedOn { get; set; }

        #endregion IAuditable Implementation
    }
}
