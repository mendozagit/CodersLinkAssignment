using CodersLinkAssignment.Domain.Entities;
using CodersLinkAssignment.Persistence.Configurations.Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodersLinkAssignment.Persistence.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");

            // Extension method to dont repeat allways the same base configuration
            builder.AddAuditableConfiguration();

            builder.Property(x => x.FirstName)
                .HasMaxLength(80)
                .IsRequired();

            builder.Property(x => x.LastName)
                .HasMaxLength(80)
                .IsRequired();

            builder.Property(x => x.Email)
                .HasMaxLength(50)
                .IsRequired(true);

            builder.Property(x => x.PhoneNumber)
                .HasMaxLength(10)
                .IsRequired(true);



        }
    }
}
