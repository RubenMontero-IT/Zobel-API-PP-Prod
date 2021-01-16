using DhubSolutions.Common.Domain.Entities.Admin;
using DhubSolutions.Reports.Domain.Entities;
using System.Collections.Generic;

namespace DhubSolutions.PerformanceParticipation.Application.Dtos.Reports
{
    public class ReportCreationDto
    {
        public string ReportName { get; set; }

        public ReportTemplate ReportTemplate { get; set; }

        public OrganizationRole OrganizationRole { get; set; }

        public Organization Organization { get; set; }

        public User User { get; set; }

        public Dictionary<string, dynamic> Parameters { get; set; }


        public void Deconstruct(
            out string name,
            out ReportTemplate reportTemplate,
            out Organization organization,
            out OrganizationRole organizationRole,
            out User user,
            out Dictionary<string, dynamic> parameters)
        {
            name = ReportName;
            reportTemplate = ReportTemplate;
            organization = Organization;
            organizationRole = OrganizationRole;
            user = User;
            parameters = Parameters;
        }
    }
}
