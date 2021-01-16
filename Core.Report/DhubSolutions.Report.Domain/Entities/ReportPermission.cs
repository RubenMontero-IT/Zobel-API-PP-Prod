using DhubSolutions.Common.Domain.Entities.Admin;
using DhubSolutions.Common.Domain.Entities.Base;
using DhubSolutions.Reports.Domain.Entities.Base;

namespace DhubSolutions.Reports.Domain.Entities
{
    public class ReportPermission : OrganizationAssignableResource, IReportPermission
    {
        public ReportPermission() : base()
        {
        }

        public string ReportId { get; set; }

        public IReport Report { get; set; }

       
    }
}
