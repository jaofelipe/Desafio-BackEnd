using DesafioBackEnd.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioBackEnd.Infra.Data.Mappings
{
    public class RentalMap : IEntityTypeConfiguration<Rental>
    {
        public void Configure(EntityTypeBuilder<Rental> builder)
        {
            builder.ToTable("Rental");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.StartDate)
                .IsRequired();

            builder.Property(r => r.EndDate);

            builder.Property(r => r.EstimatedEndDate)
                .IsRequired();

            builder.Property(r => r.TotalCost)
                .HasColumnType("decimal")
                .HasPrecision(18, 2);

            builder.Property(r => r.DailyRate)
                .IsRequired()
                .HasColumnType("decimal")
                .HasPrecision(18, 2);

            builder.Property(r => r.RentalPlan)
                .IsRequired();

            builder.Property(r => r.Status)
                .IsRequired();

            builder.HasOne(r => r.Motorcycle)
                .WithMany()
                .HasForeignKey(r => r.MotorcycleId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(r => r.DeliveryPerson)
                .WithMany(x => x.Rentals)
                .HasForeignKey(r => r.DeliveryPersonId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}