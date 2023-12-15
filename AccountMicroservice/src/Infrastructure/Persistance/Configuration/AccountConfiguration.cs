using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistance.Configuration
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {

            // Table name
            builder.ToTable("Accounts");

            // Primary key
            builder.HasKey(a => a.AccountID);

            // AccountID property configuration
            builder.Property(p => p.AccountID)
                .HasColumnName("AccountID") // Puedes ajustar el nombre de la columna según tu preferencia
                .ValueGeneratedOnAdd()
                .HasConversion(
                    accountID => accountID.Value,
                    value => new AccountID(value)
                );

            // TipoCuenta property configuration
            builder.Property(a => a.TipoCuenta)
                .HasColumnName("TipoCuenta")
                .HasMaxLength(255) // Set the maximum length if needed
                .IsRequired();

            // SaldoInicial property configuration
            builder.Property(a => a.SaldoInicial)
                .HasColumnName("SaldoInicial")
                .HasColumnType("decimal(18, 2)") // Adjust precision and scale as needed
                .IsRequired();

            // Estado property configuration
            builder.Property(a => a.Estado)
                .HasColumnName("Estado")
                .IsRequired();

            // Movimentos navigation property configuration (assuming a one-to-many relationship)
            builder.HasMany(a => a.Movimentos)
                .WithOne()
                .HasForeignKey(m => m.MovementId) // Assuming Movement has an AccountID property
                .OnDelete(DeleteBehavior.Cascade); // Adjust the delete behavior according to your requirements
        }
    }
}
