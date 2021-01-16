using DhubSolutions.Reports.Domain.Entities.Base.Permissions;
using System.Collections.Generic;

namespace DhubSolutions.Reports.Domain.Entities.Base
{
    public interface IReportElement : IBaseReportElement
    {
        /// <summary>
        /// 
        /// </summary>
        ICollection<IReportElement> Children { get; set; }

        /// <summary>
        /// 
        /// </summary>
        IReportElement Container { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string ContainerId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        IReport Report { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string ReportId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        IReportTemplateElement ReportTemplateElement { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string ReportTemplateElementId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        ICollection<IReportElementPermission> ReportElementPermissions { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<IReportElement> GetAllContent();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reportId"></param>
        /// <param name="containerId"></param>
        /// <returns></returns>
        bool UpdateUpReferences(string reportId, string containerId);
    }
}