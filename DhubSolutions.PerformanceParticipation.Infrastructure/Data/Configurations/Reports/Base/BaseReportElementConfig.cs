using DhubSolutions.Core.Domain.Entity;
using DhubSolutions.Reports.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DhubSolutions.PerformanceParticipation.Infrastructure.Data.Configurations.Reports.Base
{

    public class BaseReportElementConfig<T> : BaseEntityConfig<T>
          where T : class, IBaseReportElement, IEntity, new()
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.Name)
                .HasMaxLength(100);

            builder.Property(e => e.Code)
                .HasMaxLength(50);

            builder.Property(e => e.CreatedById)
                .HasColumnName("CreatedByID")
                .HasMaxLength(100);

            builder.Property(e => e.LastModifiedById)
                .HasColumnName("LastModifiedByID")
                .HasMaxLength(100);

            builder.Property(e => e.CreationDate)
              .HasColumnType("datetime");

            builder.Property(e => e.LastModified)
                .HasColumnType("datetime");

            builder.Property(e => e.Config);

            builder.Property(e => e.Description)
                .HasMaxLength(250);

        }
    }
}
