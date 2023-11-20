using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpenBaseNET.Domain.Entities;

namespace OpenBaseNET.Infra.Data.Context.Configurations
{
    internal sealed class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("CLITAB");

            builder.HasKey(c => c.Id)
                .HasName("PK_CLITAB");

            builder.Property(c => c.Id).HasColumnName("CLIID");
            builder.Property(c => c.Name).HasColumnName("CLINM").IsRequired().HasMaxLength(25);
        }
    }
}