using DhubSolutions.PerformanceParticipation.Infrastructure.Data.Configurations.Reports.Base;
using DhubSolutions.Reports.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DhubSolutions.PerformanceParticipation.Infrastructure.Data.Configurations.Reports
{
    public class ReportTemplateConfig : BaseReportConfig<ReportTemplate>
    {
        public override void Configure(EntityTypeBuilder<ReportTemplate> builder)
        {
            base.Configure(builder);

            builder.ToTable("ReportTemplate", "ppart");

            builder.HasOne(e => e.CreatedBy)
                   .WithMany()
                   .HasForeignKey(e => e.CreatedById)
                   .HasConstraintName("FK_ReportTemplate_User");
        }
    }
}
