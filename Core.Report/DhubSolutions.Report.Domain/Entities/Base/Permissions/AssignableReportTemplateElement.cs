using DhubSolutions.Common.Domain.Entities.Base;

namespace DhubSolutions.Reports.Domain.Entities.Base.Permissions
{
    /// <summary>
    /// 
    /// </summary>
    public class AssignableReportTemplateElement : AssignableResource, IAssignableReportTemplateElement
    {
        /// <summary>
        /// 
        /// </summary>
        protected AssignableReportTemplateElement()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public string ReportTemplateElementId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ReportTemplateElement ReportTemplateElement { get; set; }
    }
}
