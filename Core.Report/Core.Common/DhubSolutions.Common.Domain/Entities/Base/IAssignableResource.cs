using DhubSolutions.Common.Domain.Entities.Admin;

namespace DhubSolutions.Common.Domain.Entities.Base
{
    public interface IAssignableResource 
    {
        /// <summary>
        /// 
        /// </summary>
        string PermissionId { get; }

        /// <summary>
        /// 
        /// </summary>
        Permission Permission { get; }

    }


}
