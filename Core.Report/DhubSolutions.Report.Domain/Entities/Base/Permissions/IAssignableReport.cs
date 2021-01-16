using DhubSolutions.Common.Domain.Entities.Base;

namespace DhubSolutions.Reports.Domain.Entities.Base.Permissions
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAssignableReport : IAssignableResource
    {
        /// <summary>
        /// 
        /// </summary>
        public string ReportId { get; }

        /// <summary>
        /// 
        /// </summary>
        public Report Report { get; set; }
    }
}
