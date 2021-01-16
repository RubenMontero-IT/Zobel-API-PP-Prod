using DhubSolutions.PerformanceParticipation.Infrastructure.Data.Configurations.Reports.Base;
using DhubSolutions.Reports.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DhubSolutions.PerformanceParticipation.Infrastructure.Data.Configurations.Reports
{
    public class ReportConfig : BaseReportConfig<Report>
    {
        public override void Configure(EntityTypeBuilder<Report> builder)
        {
            base.Configure(builder);

            builder.ToTable("Report", "ppart");

            builder.Property(e => e.CreationOptions)
                .HasColumnName("CreationOptions")
                .IsRequired();

            builder.Property(e => e.ReportTemplateId)
                .HasColumnName("ReportTemplateID");

            builder.HasOne(d => d.ReportTemplate)
                .WithMany()
                .HasForeignKey(d => d.ReportTemplateId)
                .HasConstraintName("FK_Report_ReportTemplate")
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(e => e.CreatedBy)
                .WithMany()
                .HasForeignKey(e => e.CreatedById)
                .HasConstraintName("FK_Report_User");
        }
    }
}
