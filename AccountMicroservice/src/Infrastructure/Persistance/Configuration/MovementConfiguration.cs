using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.Configuration
{
    public class MovementConfiguration : IEntityTypeConfiguration<Movement>
    {
        public void Configure(EntityTypeBuilder<Movement> builder)
        {
            // Table name
            builder.ToTable("Movements");

            // Primary key
            builder.HasKey(m => m.MovementId);

            // MovementId property configuration
            builder.Property(p => p.MovementId)
               .HasColumnName("MovementId") // Puedes ajustar el nombre de la columna según tu preferencia
               .ValueGeneratedOnAdd()
               .HasConversion(
                   movementId => movementId.Value,
                   value => new MovementId(value)
               );

            // Fecha property configuration
            builder.Property(m => m.Fecha)
                .HasColumnName("Fecha")
                .IsRequired();

            // TipoMovimiento property configuration
            builder.Property(m => m.TipoMovimiento)
                .HasColumnName("TipoMovimiento")
                .HasMaxLength(255) // Set the maximum length if needed
                .IsRequired();

            // Valor property configuration
            builder.Property(m => m.Valor)
                .HasColumnName("Valor")
                .HasColumnType("decimal(18, 2)"); // Adjust precision and scale as needed

            // Saldo property configuration
            builder.Property(m => m.Saldo)
                .HasColumnName("Saldo")
                .HasColumnType("decimal(18, 2)"); // Adjust precision and scale as needed

            // Description property configuration
            builder.Ignore(m => m.descripcion);

            // Configure the relationship with Account (assuming a many-to-one relationship)
            builder.HasOne<Account>()
                .WithMany(a => a.Movimentos)
                .HasForeignKey(m =>m.AccountFk ) // Assuming Movement has an AccountID property
                .OnDelete(DeleteBehavior.Cascade); // Adjust the delete behavior according to your requirements
        }

    }
}
    
