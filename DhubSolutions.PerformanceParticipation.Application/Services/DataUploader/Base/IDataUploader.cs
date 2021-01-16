using DhubSolutions.PerformanceParticipation.Domain.Entities.DataUploader.Base;
using System.Collections.Generic;

namespace DhubSolutions.PerformanceParticipation.Application.Services.DataUploader.Base
{
    public interface IDataUploaderService
    {
        void Insert<T>(List<T> insertItems) where T : class, IDataUploaderDataRow, new();

        void Delete<T>() where T : class, new();
    }
}
