using DhubSolutions.Common.Domain.Entities.Base;

namespace DhubSolutions.Reports.Domain.Entities.Base.Permissions
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class AssignableReportElement : AssignableResource, IAssignableReportElement
    {
        /// <summary>
        /// 
        /// </summary>
        protected AssignableReportElement() : base()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public string ReportElementId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ReportElement ReportElement { get; set; }
    }
}
