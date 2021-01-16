using DhubSolutions.Reports.Domain.Entities.Base.Permissions;
using System.Collections.Generic;

namespace DhubSolutions.Reports.Domain.Entities.Base
{
    public interface IReportTemplateElement : IBaseReportElement
    {
        /// <summary>
        /// 
        /// </summary>
        ICollection<IReportTemplateElement> Children { get; set; }

        /// <summary>
        /// 
        /// </summary>
        IReportTemplateElement Container { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string ContainerId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        IReportTemplate ReportTemplate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string ReportTemplateId { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        ICollection<IReportTemplateElementPermission> ReportTemplateElementPermissions { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<IReportTemplateElement> GetAllContent();
        
    }
}