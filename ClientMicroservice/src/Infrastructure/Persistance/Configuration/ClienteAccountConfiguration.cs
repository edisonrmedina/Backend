using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistance.Configuration
{
    public class ClienteAccountConfiguration : IEntityTypeConfiguration<ClienteAccount>
    {
        public void Configure(EntityTypeBuilder<ClienteAccount> builder)
        {
            builder.ToTable("ClienteCluenta");
            // Configuración específica de ClienteAccount
            builder.Property(c => c.Contraseña).IsRequired();
            builder.Property(c => c.Estado).IsRequired();

            // Configuración de la herencia de Persona
           
            builder.HasBaseType<Persona>();

        }
    }
}
