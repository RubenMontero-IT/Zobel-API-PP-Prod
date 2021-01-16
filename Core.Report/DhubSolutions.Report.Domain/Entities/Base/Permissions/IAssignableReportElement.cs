using DhubSolutions.Common.Domain.Entities.Base;

namespace DhubSolutions.Reports.Domain.Entities.Base.Permissions
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAssignableReportElement : IAssignableResource
    {
        /// <summary>
        /// 
        /// </summary>
        public string ReportElementId { get; }

        /// <summary>
        /// 
        /// </summary>
        public ReportElement ReportElement { get; }
    }
}
