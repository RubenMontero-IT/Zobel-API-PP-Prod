using System.Collections.Generic;

namespace DhubSolutions.PerformanceParticipation.Api.ViewModels.Reports
{
    public class ReportContentVM
    {
        public string Name { get; set; }

        public ICollection<ReportElementVM> Added { get; set; }

        public ICollection<ReportElementVM> Updated { get; set; }

        public ICollection<string> Removed { get; set; }
    }
}
