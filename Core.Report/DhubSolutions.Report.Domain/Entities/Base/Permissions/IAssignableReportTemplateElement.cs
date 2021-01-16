using DhubSolutions.Common.Domain.Entities.Base;

namespace DhubSolutions.Reports.Domain.Entities.Base.Permissions
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAssignableReportTemplateElement : IAssignableResource
    {
        /// <summary>
        /// 
        /// </summary>
        public string ReportTemplateElementId { get; }

        /// <summary>
        /// 
        /// </summary>
        public ReportTemplateElement ReportTemplateElement { get; }
    }


}
