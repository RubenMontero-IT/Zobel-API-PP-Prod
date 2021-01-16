using DhubSolutions.PerformanceParticipation.Infrastructure.Data.Configurations.Reports.Base;
using DhubSolutions.Reports.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DhubSolutions.PerformanceParticipation.Infrastructure.Data.Configurations.Reports
{
    public class ReportElementConfig : BaseReportElementConfig<ReportElement>
    {
        public override void Configure(EntityTypeBuilder<ReportElement> builder)
        {
            base.Configure(builder);

            builder.ToTable("ReportElement", "ppart");

            builder.Property(e => e.ReportId)
                .HasColumnName("ReportID");

            builder.Property(e => e.ContainerId)
                .HasColumnName("ContainerID");

            builder.Property(e => e.ReportTemplateElementId)
                .HasColumnName("ReportTemplateElementID");

            builder.HasOne(d => d.Report)
                .WithMany(p => p.Content)
                .HasForeignKey(d => d.ReportId)
                .HasConstraintName("FK_ReportElement_Report")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(d => d.Container)
                .WithMany(p => p.Children)
                .HasForeignKey(d => d.ContainerId)
                .HasConstraintName("FK_ReportElement_ReportElement")
                /*.OnDelete(DeleteBehavior.Cascade)*/;

            builder.HasOne(d => d.ReportTemplateElement)
             .WithMany()
             .HasForeignKey(d => d.ReportTemplateElementId)
             .HasConstraintName("FK_ReportElement_ReportTemplateElement")
             .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
