using DesafioBackEnd.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioBackEnd.Infra.Data.Mappings
{
    public class MotorcycleMap : IEntityTypeConfiguration<Motorcycle>
    {
        public void Configure(EntityTypeBuilder<Motorcycle> builder)
        {
            // Nome da tabela
            builder.ToTable("Motorcycle");

            // Chave primária
            builder.HasKey(m => m.Id);

            // Propriedade Id
            builder.Property(m => m.Id)
                   .ValueGeneratedNever() // Como está sendo usado Guid.NewGuid(), não é gerado pelo banco
                   .IsRequired();

            // Propriedade Year
            builder.Property(m => m.Year)
                   .IsRequired();

            // Propriedade Model
            builder.Property(m => m.Model)
                   .IsRequired()
                   .HasMaxLength(100); // Limite de tamanho

            // Propriedade LicensePlate
            builder.Property(m => m.LicensePlate)
                   .IsRequired()
                   .HasMaxLength(12);

            // Índice único para LicensePlate
            builder.HasIndex(m => m.LicensePlate)
                   .IsUnique();

            
        }
    }
}