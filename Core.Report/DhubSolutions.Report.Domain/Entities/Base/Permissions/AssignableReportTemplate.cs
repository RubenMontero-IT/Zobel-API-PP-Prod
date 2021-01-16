using DhubSolutions.Common.Domain.Entities.Base;

namespace DhubSolutions.Reports.Domain.Entities.Base.Permissions
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class AssignableReportTemplate : AssignableResource, IAssignableReportTemplate
    {
        /// <summary>
        /// 
        /// </summary>
        protected AssignableReportTemplate() : base()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        public string ReportTemplateId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ReportTemplate ReportTemplate { get; set; }
    }
}
