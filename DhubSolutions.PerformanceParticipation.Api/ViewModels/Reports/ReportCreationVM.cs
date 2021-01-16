using System.Collections.Generic;

namespace DhubSolutions.PerformanceParticipation.Api.ViewModels.Reports
{
    public class ReportCreationVM
    {
        public string ReportName { get; set; }

        public string TemplateId { get; set; }

        public string OrganizationId { get; set; }

        public Dictionary<string, dynamic> Parameters { get; set; }

        public void Deconstruct(
            out string name,
            out string reportTemplateId,
            out string organizationId,
            out Dictionary<string, dynamic> parameters)
        {
            name = ReportName;
            reportTemplateId = TemplateId;
            organizationId = OrganizationId;
            parameters = Parameters;
        }
    }
}
