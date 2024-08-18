using DesafioBackEnd.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioBackEnd.Infra.Data.Mappings;

public class Motorcycle2024RegistrationMap : IEntityTypeConfiguration<Motorcycle2024Registration>
{
    public void Configure(EntityTypeBuilder<Motorcycle2024Registration> builder)
    {
        // Nome da tabela
        builder.ToTable("Motorcycle2024Registration");

        // Chave primária
        builder.HasKey(m => m.Id);

        // Propriedade Id
        builder.Property(m => m.Id)
               .ValueGeneratedNever() // Como está sendo usado Guid.NewGuid(), não é gerado pelo banco
               .IsRequired();

        builder.Property(m => m.MotorcycleId)
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
