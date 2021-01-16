using DhubSolutions.Common.Domain.Entities.Admin;
using DhubSolutions.Reports.Domain.Entities.Extensions;

namespace DhubSolutions.Reports.Domain.Entities.Extensions
{
    public static class ReportElementExtension
    {
        public static bool IsAccessible(this ReportElement reportElement, OrganizationRole organizationRole, Permission permission)
        {
            return reportElement.ReportTemplateElement.IsAccessible(organizationRole, permission);
        }
    }
}
