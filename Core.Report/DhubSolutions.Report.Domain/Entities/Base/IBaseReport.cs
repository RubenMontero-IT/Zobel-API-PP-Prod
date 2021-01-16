using DhubSolutions.Common.Domain.Entities.Admin;
using DhubSolutions.Core.Domain.Entity;
using Newtonsoft.Json.Linq;
using System;

namespace DhubSolutions.Reports.Domain.Entities.Base
{
    public interface IBaseReport : IEntity
    {
        /// <summary>
        /// 
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string Metadata { get; set; }

        /// <summary>
        /// 
        /// </summary>
        JObject MetadataJObject { get; }

        /// <summary>
        /// 
        /// </summary>
        string Data { get; set; }

        /// <summary>
        /// 
        /// </summary>
        JObject DataJObject { get; }

        /// <summary>
        /// 
        /// </summary>
        string CreatedById { get; set; }

        /// <summary>
        /// 
        /// </summary>
        User CreatedBy { get; set; }

        /// <summary>
        /// 
        /// </summary>
        DateTime CreationDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        DateTime LastModified { get; set; }

    }
}