using System;

namespace DhubSolutions.PerformanceParticipation.Domain.Entities.DataUploader.Base
{
    public interface IDataUploaderDataRow
    {
        public DateTime? UpdateDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
