using DhubSolutions.Common.Domain.Entities.Admin;
using Newtonsoft.Json.Linq;
using System;


namespace DhubSolutions.Reports.Domain.Entities.Base
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBaseReportElement 
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
        string Code { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string Type { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string Config { get; set; }

        /// <summary>
        /// 
        /// </summary>
        JObject ConfigJObject { get; }

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
        string LastModifiedById { get; set; }

        /// <summary>
        /// 
        /// </summary>
        User LastModifiedBy { get; set; }

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