using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpenBaseNET.Domain.Entities;

namespace OpenBaseNET.Infra.Data.Context.Configurations;

internal sealed class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customer");

        builder.HasKey(c => c.Id)
            .HasName("Customer_Pk");

        builder
            .Property(c => c.Id)
            .HasColumnName("Id");

        builder
            .OwnsOne(
                c => c.Name,
                name =>
            {
                name.Property(n => n.Value)
                .HasColumnName("Name")
                .HasMaxLength(255)
                .IsRequired();
            });
    }
}