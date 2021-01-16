using DhubSolutions.Core.Domain.Data;
using DhubSolutions.PerformanceParticipation.Application.Services.DataUploader.Base;
using DhubSolutions.PerformanceParticipation.Domain.Entities.DataUploader.Base;
using DhubSolutions.PerformanceParticipation.Domain.Repositories.DataUploader;
using System;
using System.Collections.Generic;

namespace DhubSolutions.PerformanceParticipation.Application.Services.DataUploader
{
    public class DataUploaderService : IDataUploaderService
    {


        private readonly IUnitOfWork _unitOfWork;
        private readonly IDataUploaderRepository _dataUploaderRepository;

        public DataUploaderService(IUnitOfWork unitOfWork, IDataUploaderRepository dataUploaderRepository)
        {
            _unitOfWork = unitOfWork;
            _dataUploaderRepository = dataUploaderRepository;
        }


        public void Insert<T>(List<T> insertItems) where T : class, IDataUploaderDataRow, new()
        {
            if (insertItems != null)
            {
                Delete<T>();
                var labdae = new Action<IDataUploaderDataRow>(e =>
                {
                    e.UpdateDate = DateTime.Now;
                });
                insertItems.ForEach(labdae);
                foreach (T item in insertItems)
                {
                    _dataUploaderRepository.Insert(item);
                }
            }
        }


        public void Delete<T>() where T : class, new()
        {
            _dataUploaderRepository.Delete<T>();
        }
    }
}
