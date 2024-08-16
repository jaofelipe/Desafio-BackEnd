using DesafioBackEnd.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DesafioBackEnd.Infra.Data.Mappings;

public class DeliveryPersonMap : IEntityTypeConfiguration<DeliveryPerson>
{
    public void Configure(EntityTypeBuilder<DeliveryPerson> builder)
    {
        builder.ToTable("DeliveryPerson");

        builder.HasKey(dp => dp.Id);

        builder.Property(m => m.Id)
          .ValueGeneratedNever() // Como está sendo usado Guid.NewGuid(), não é gerado pelo banco
          .IsRequired();

        builder.Property(dp => dp.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(dp => dp.Cnpj)
            .IsRequired()
            .HasMaxLength(14);

        builder.HasIndex(dp => dp.Cnpj)
            .IsUnique();

        builder.Property(dp => dp.BirthDate)
            .IsRequired();

        builder.Property(dp => dp.DriverLicenseNumber)
            .IsRequired()
            .HasMaxLength(20);

        builder.HasIndex(dp => dp.DriverLicenseNumber)
            .IsUnique();

        builder.Property(dp => dp.LicenseType)
            .IsRequired();


        builder.HasMany(dp => dp.Rentals)
            .WithOne(r => r.DeliveryPerson)
            .HasForeignKey(r => r.DeliveryPersonId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

