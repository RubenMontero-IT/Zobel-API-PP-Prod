using DhubSolutions.Core.Domain.Data;
using DhubSolutions.Core.Infrastructure.Data.Repositories;
using DhubSolutions.PerformanceParticipation.Domain.Repositories.Reports;
using DhubSolutions.PerformanceParticipation.Infrastructure.Data.Context;
using DhubSolutions.Reports.Domain.Entities;

namespace DhubSolutions.PerformanceParticipation.Infrastructure.Data.Repositories.Reports
{
    /// <summary>
    /// 
    /// </summary>
    public class ReportElementRepository : Repository<ReportElement>, IReportElementRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="unitOfWork"></param>
        public ReportElementRepository(PerformanceParticipationDbContext context, IUnitOfWork unitOfWork)
            : base(context, unitOfWork)
        {
        }


    }
}
