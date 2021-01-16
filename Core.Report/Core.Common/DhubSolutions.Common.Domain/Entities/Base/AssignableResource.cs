using DhubSolutions.Common.Domain.Entities.Admin;
using DhubSolutions.Core.Domain.Entity;

namespace DhubSolutions.Common.Domain.Entities.Base
{
    public abstract class AssignableResource : BaseEntity, IAssignableResource
    {
        protected AssignableResource()
        { }
        public string PermissionId { get; set; }

        public Permission Permission { get; set; }

    }
}
