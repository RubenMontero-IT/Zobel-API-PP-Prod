using DhubSolutions.Common.Domain.Entities.Admin;
using DhubSolutions.Common.Domain.Repositories.Admin;
using DhubSolutions.Core.Domain.Data;
using DhubSolutions.Core.Infrastructure.Data.Repositories;
using DhubSolutions.PerformanceParticipation.Infrastructure.Data.Context;
using System.Collections.Generic;

namespace DhubSolutions.PerformanceParticipation.Infrastructure.Data.Repositories.Admin
{
    public class OrganizationRoleRepository : Repository<OrganizationRole>, IOrganizationRoleRepository
    {
        public OrganizationRoleRepository(PerformanceParticipationDbContext context, IUnitOfWork unitOfWork)
            : base(context, unitOfWork)
        { }

        public IEnumerable<SystemGroupMemberShip> GetSystemGroupMemberShips(string orgRoleId)
        {
            throw new System.NotImplementedException();
        }
    }
}
