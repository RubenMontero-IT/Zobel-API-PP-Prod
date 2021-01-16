using System.Collections.Generic;

namespace DhubSolutions.PerformanceParticipation.Application.Dtos.Reports
{
    public class ReportContentDto
    {
        public string ReportId { get; set; }

        public string Name { get; set; }

        public string UserId { get; set; }

        public ICollection<ReportElementDto> Added { get; set; }

        public ICollection<ReportElementDto> Updated { get; set; }

        public ICollection<string> Removed { get; set; }

    }
}
