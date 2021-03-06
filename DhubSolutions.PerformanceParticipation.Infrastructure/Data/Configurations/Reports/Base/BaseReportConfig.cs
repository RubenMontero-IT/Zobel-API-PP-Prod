﻿using DhubSolutions.Core.Domain.Entity;
using DhubSolutions.Reports.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DhubSolutions.PerformanceParticipation.Infrastructure.Data.Configurations.Reports.Base
{
    public class BaseReportConfig<T> : BaseEntityConfig<T>, IEntityTypeConfiguration<T>
        where T : class, IBaseReport, IEntity, new()
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.CreatedById)
                .HasColumnName("CreatedByID")
                .HasMaxLength(100);

            builder.Property(e => e.CreationDate)
                .HasColumnType("datetime");

            builder.Property(e => e.LastModified)
                .HasColumnType("datetime");

            builder.Property(e => e.Metadata);

            builder.Property(e => e.Data);

            builder.Property(e => e.Description)
                .HasMaxLength(250);
        }
    }
}
