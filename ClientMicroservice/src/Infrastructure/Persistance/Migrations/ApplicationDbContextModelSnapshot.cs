﻿// <auto-generated />
using System;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Persistance.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Persona", b =>
                {
                    b.Property<Guid>("PersonaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("PersonaId");

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Identificacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonaId");

                    b.ToTable("Personas", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("Domain.ClienteAccount", b =>
                {
                    b.HasBaseType("Domain.Persona");

                    b.Property<string>("Contraseña")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.ToTable("ClienteCluenta", (string)null);
                });

            modelBuilder.Entity("Domain.Persona", b =>
                {
                    b.OwnsOne("Domain.ValueObjects.Direccion", "Direccion", b1 =>
                        {
                            b1.Property<Guid>("PersonaId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Calle")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Ciudad")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("PersonaId");

                            b1.ToTable("Personas");

                            b1.WithOwner()
                                .HasForeignKey("PersonaId");
                        });

                    b.Navigation("Direccion")
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.ClienteAccount", b =>
                {
                    b.HasOne("Domain.Persona", null)
                        .WithOne()
                        .HasForeignKey("Domain.ClienteAccount", "PersonaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
