using System;

namespace DhubSolutions.PerformanceParticipation.Api.ViewModels.Reports
{
    public class ShortReportVM
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Organization { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
