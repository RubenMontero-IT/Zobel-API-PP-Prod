using DhubSolutions.PerformanceParticipation.Domain.Entities.DataUploader.Base;
using System;

namespace DhubSolutions.PerformanceParticipation.Domain.Entities.DataUploader
{
    public class PerfPartcipationDetails_x : IDataUploaderDataRow
    {       
        public string OrganizationName { get; set; }
        public int Order { get; set; }
        public string MainCategory { get; set; }
        public string ItemDescription { get; set; }
        public string SubCategory { get; set; }
        public int Year { get; set; }
        public int Amount { get; set; }
        public DateTime? UpdateDate { get; set; }  
        public string UpdatedBy { get; set; }
    }
}
