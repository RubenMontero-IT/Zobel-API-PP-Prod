using DhubSolutions.PerformanceParticipation.Infrastructure.Data.Configurations.Reports.Base;
using DhubSolutions.Reports.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DhubSolutions.PerformanceParticipation.Infrastructure.Data.Configurations.Reports
{
    public class ReportTemplateElementConfig : BaseReportElementConfig<ReportTemplateElement>
    {
        public override void Configure(EntityTypeBuilder<ReportTemplateElement> builder)
        {
            base.Configure(builder);

            builder.ToTable("ReportTemplateElement", "ppart");

            builder.Property(e => e.ReportTemplateId)
                .HasColumnName("ReportTemplateID");

            builder.Property(e => e.ContainerId)
                .HasColumnName("ContainerID");

            builder.HasOne(d => d.ReportTemplate)
                .WithMany(p => p.Content)
                .HasForeignKey(d => d.ReportTemplateId)
                .HasConstraintName("FK_ReportTemplateElement_ReportTemplate")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(d => d.Container)
                .WithMany(p => p.Children)
                .HasForeignKey(d => d.ContainerId)
                .HasConstraintName("FK_ReportTemplatetElement_ReportTemplateElement")
                /*.OnDelete(DeleteBehavior.Cascade)*/;
        }
    }
}
