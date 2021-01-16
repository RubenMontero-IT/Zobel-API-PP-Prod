using DhubSolutions.Common.Domain.Entities.Base;
using DhubSolutions.Reports.Domain.Entities.Base;

namespace DhubSolutions.Reports.Domain.Entities
{
    public class ReportElementPermission : AssignableResource, IReportElementPermission
    {
        public ReportElementPermission() : base()
        {
        }
        public string ReportElementId { get; set; }
        public IReportElement ReportElement { get; set; }
    }
}
