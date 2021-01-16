namespace DhubSolutions.PerformanceParticipation.Domain.Repositories.DataUploader
{
    public interface IDataUploaderRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="organizationId"></param>
        /// <param name="periodId"></param>
        void Delete<T>() where T : class, new();

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        void Insert<T>(T entity) where T : class, new();

      
    }
}
