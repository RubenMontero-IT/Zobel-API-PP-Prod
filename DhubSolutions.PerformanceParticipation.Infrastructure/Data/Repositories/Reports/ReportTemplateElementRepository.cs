using DhubSolutions.Core.Domain.Data;
using DhubSolutions.Core.Infrastructure.Data.Repositories;
using DhubSolutions.PerformanceParticipation.Domain.Repositories.Reports;
using DhubSolutions.PerformanceParticipation.Infrastructure.Data.Context;
using DhubSolutions.Reports.Domain.Entities;

namespace DhubSolutions.PerformanceParticipation.Infrastructure.Data.Repositories.Reports
{
    public class ReportTemplateElementRepository : Repository<ReportTemplateElement>, IReportTemplateElementRepository
    {
        public ReportTemplateElementRepository(PerformanceParticipationDbContext dbContext, IUnitOfWork unitOfWork)
            : base(dbContext, unitOfWork)
        { }
    }
}
