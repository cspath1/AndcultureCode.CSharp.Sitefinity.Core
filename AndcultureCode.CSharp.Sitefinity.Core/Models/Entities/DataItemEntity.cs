using AndcultureCode.CSharp.Sitefinity.Core.Interfaces;
using System;
using Telerik.Sitefinity.Model;

namespace AndcultureCode.CSharp.Sitefinity.Core.Models.Entities
{
    public abstract class DataItemEntity : IDataItem
    {
        public string   ApplicationName { get; set; }
        public Guid     Id              { get; set; }
        public DateTime LastModified    { get; set; }
        public object   Provider        { get; set; }
        public object   Transaction     { get; set; }
    }
}
