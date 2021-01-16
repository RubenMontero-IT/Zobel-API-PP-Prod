using DhubSolutions.PerformanceParticipation.Domain.Entities.DataUploader;
using System.Collections.Generic;

namespace DhubSolutions.PerformanceParticipation.Application.Dtos.DataUploader
{
    public class JsonInputDto
    {
        public List<PerfPartcipationDetails_x> PerfPartcipationDetails { get; set; }
    }
}
