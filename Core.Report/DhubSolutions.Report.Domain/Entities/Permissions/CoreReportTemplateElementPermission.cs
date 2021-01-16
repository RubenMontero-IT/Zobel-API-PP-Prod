using DhubSolutions.Common.Domain.Entities.Base;
using DhubSolutions.Reports.Domain.Entities.Base;
using DhubSolutions.Reports.Domain.Entities.Base.Permissions;

namespace DhubSolutions.Reports.Domain.Entities.Permissions
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class CoreReportTemplateElementPermission : AssignableResource, IReportTemplateElementPermission
    {
        protected CoreReportTemplateElementPermission()
        { }

        /// <summary>
        /// 
        /// </summary>
        public IReportTemplateElement ReportTemplateElement { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ReportTemplateElementId { get; set; }
    }
}
