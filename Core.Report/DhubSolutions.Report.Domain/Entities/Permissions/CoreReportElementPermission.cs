using DhubSolutions.Common.Domain.Entities.Base;
using DhubSolutions.Reports.Domain.Entities.Base;
using DhubSolutions.Reports.Domain.Entities.Base.Permissions;

namespace DhubSolutions.Reports.Domain.Entities.Permissions
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class CoreReportElementPermission : AssignableResource, IReportElementPermission
    {
        protected CoreReportElementPermission()
        { }

        /// <summary>
        /// 
        /// </summary>
        public IReportElement ReportElement { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string ReportElementId { get; set; }
    }
}
