using DhubSolutions.Common.Domain.Entities.Base;
using DhubSolutions.Reports.Domain.Entities.Base;
using DhubSolutions.Reports.Domain.Entities.Base.Permissions;

namespace DhubSolutions.Reports.Domain.Entities.Permissions
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class CoreReportPermission : AssignableResource, IReportPermission
    {
        protected CoreReportPermission()
        { }

        /// <summary>
        /// 
        /// </summary>
        public IReport Report { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ReportId { get; set; }
    }
}
