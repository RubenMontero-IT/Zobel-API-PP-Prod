using System.Threading.Tasks;

namespace DhubSolutions.PerformanceParticipation.Domain.Repositories.Reports
{
    public interface IReportDataRepository
    {
        /// <summary>
        /// 
        /// </summary>        
        /// <returns></returns>
        public Task<string> GetOrganizations();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="initialYear"></param>
        /// <param name="endYear"></param>
        /// <returns></returns>
        public Task<string> GetPerformanceDetails(int? initialYear, int? endYear);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="initialYear"></param>
        /// <param name="endYear"></param>
        /// <param name="mainCategory"></param>
        /// <param name="accountLevelID"></param>
        /// <returns></returns>
        public Task<string> GetNormalizationDetails(int? initialYear, int? endYear, string mainCategory, string accountLevelID);
    }
}
