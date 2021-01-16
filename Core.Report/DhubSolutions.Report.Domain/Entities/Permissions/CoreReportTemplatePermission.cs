using DhubSolutions.Common.Domain.Entities.Base;
using DhubSolutions.Reports.Domain.Entities.Base;
using DhubSolutions.Reports.Domain.Entities.Base.Permissions;

namespace DhubSolutions.Reports.Domain.Entities.Permissions
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class CoreReportTemplatePermission : AssignableResource, IReportTemplatePermission
    {
        protected CoreReportTemplatePermission()
        { }

        /// <summary>
        /// 
        /// </summary>
        public IReportTemplate ReportTemplate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ReportTemplateId { get; set; }
    }
}
