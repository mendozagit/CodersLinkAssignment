using CodersLinkAssignment.Domain.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodersLinkAssignment.Persistence.Configurations.Helper
{
    public static class ConfigurationExtensions
    {
        public static void AddAuditableConfiguration<TEntity>(this EntityTypeBuilder<TEntity> builder)
            where TEntity : AuditableBaseEntity
        {
            //Base Model Configurations//
            builder.HasIndex(x => x.Id);


            builder.Property(x => x.CreatedBy)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.UpdatedBy)
                .IsRequired(false)
                .HasMaxLength(50);

            builder.Property(x => x.UpdatedAt)
                .IsRequired(false);

            builder.Property(x => x.CreatedAt)
                .IsRequired();

            builder.Property(x => x.RowVersion)
                .IsRowVersion();
        }
    }
}
