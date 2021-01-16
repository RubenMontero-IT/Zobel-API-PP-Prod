using DhubSolutions.Common.Domain.Entities.Base;

namespace DhubSolutions.Reports.Domain.Entities.Base.Permissions
{
    /// <summary>
    /// /
    /// </summary>
    public interface IAssignableReportTemplate : IAssignableResource
    {
        /// <summary>
        /// 
        /// </summary>
        public string ReportTemplateId { get; }

        /// <summary>
        /// 
        /// </summary>
        public ReportTemplate ReportTemplate { get; }
    }
}
