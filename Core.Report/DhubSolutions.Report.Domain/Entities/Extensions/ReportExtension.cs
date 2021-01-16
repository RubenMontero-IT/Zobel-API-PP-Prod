using DhubSolutions.Common.Domain.Entities.Admin;
using DhubSolutions.Reports.Domain.Entities.Extensions;

namespace DhubSolutions.Reports.Domain.Entities.Extensions
{
    public static class ReportExtension
    {
        public static bool IsAccessible(this Report report, OrganizationRole organizationRole, Permission permission)
        {
            return report.Template.IsAccessible(organizationRole, permission);
        }
    }
}
