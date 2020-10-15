using AndcultureCode.CSharp.Core.Interfaces;
using AndcultureCode.CSharp.Sitefinity.Core.Interfaces.Conductors;
using AndcultureCode.CSharp.Sitefinity.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndcultureCode.CSharp.Sitefinity.Core.Conductors
{
    public class CustomProviderUpdateConductor : CustomProviderConductorBase, ICustomProviderUpdateConductor
    {
        public virtual IResult<bool> Update<T>(
            T     item,
            Guid? updatedById = null
        ) where T : DataItemEntity => getProvider().Update(item, updatedById);

        public virtual IResult<bool> Update<T>(
            IEnumerable<T> items,
            Guid?          updatedById = null
        ) where T : DataItemEntity => getProvider().Update(items, updatedById);
    }
}
