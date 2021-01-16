using DhubSolutions.Common.Domain.Entities.Admin;
using DhubSolutions.Common.Domain.Repositories.Admin;
using DhubSolutions.Core.Domain.Data;
using DhubSolutions.Core.Infrastructure.Data.Repositories;
using DhubSolutions.PerformanceParticipation.Infrastructure.Data.Context;

namespace DhubSolutions.PerformanceParticipation.Infrastructure.Data.Repositories.Admin
{
    public class OrganizationRepository : Repository<Organization>, IOrganizationRepository
    {
        public OrganizationRepository(PerformanceParticipationDbContext context, IUnitOfWork unitOfWork)
            : base(context, unitOfWork)
        { }
    }
}
