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
    public class PersonConfiguration : IEntityTypeConfiguration<Persona>
    {
        public void Configure(EntityTypeBuilder<Persona> builder)
        {
            builder.ToTable("Personas");

            builder.HasKey(p => p.PersonaId);

            builder.Property(p => p.PersonaId)
                .HasColumnName("PersonaId") // Puedes ajustar el nombre de la columna según tu preferencia
                .ValueGeneratedOnAdd()
                .HasConversion(
                    personaId => personaId.Value,
                    value => new PersonaId(value)
                );



            builder.Property(p => p.Nombre).IsRequired();
            builder.Property(p => p.Genero).IsRequired();
            builder.Property(p => p.Edad).IsRequired();
            builder.Property(p => p.Identificacion).IsRequired();
            builder.OwnsOne(p => p.Direccion, dir =>
            {
                dir.Property(d => d.Calle).IsRequired();
                dir.Property(d => d.Ciudad).IsRequired();
            });
            builder.Property(p => p.Telefono).IsRequired();

         }
    }
    
}
