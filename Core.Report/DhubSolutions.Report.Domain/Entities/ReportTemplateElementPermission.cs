using DhubSolutions.Common.Domain.Entities.Base;

namespace DhubSolutions.Reports.Domain.Entities
{
    public class ReportTemplateElementPermission : AssignableResource, IReportTemplateElementPermission
    {
        public ReportTemplateElementPermission() : base()
        { }

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
