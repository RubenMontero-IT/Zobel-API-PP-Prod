using DhubSolutions.Reports.Domain.Entities.Base.Permissions;
using System.Collections.Generic;

namespace DhubSolutions.Reports.Domain.Entities.Base
{
    public interface IReportTemplate : IBaseReport
    {
        /// <summary>
        /// 
        /// </summary>
        string Code { get; set; }

        /// <summary>
        /// 
        /// </summary>
        ICollection<IReportTemplateElement> Content { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        ICollection<IReportTemplatePermission> ReportTemplatePermissions { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<IReportTemplateElement> GetAllContent();
    }
}