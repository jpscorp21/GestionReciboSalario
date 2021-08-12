﻿// <auto-generated />
using System;
using GestionReciboSalario.API.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace GestionReciboSalario.API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210811194520_recibo")]
    partial class recibo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("GestionReciboSalario.API.Entities.Empleado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("NombreEmpleado")
                        .HasColumnType("text")
                        .HasColumnName("nombre_empleado");

                    b.Property<string>("Password")
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.Property<int>("Rol")
                        .HasColumnType("integer")
                        .HasColumnName("rol");

                    b.Property<string>("Usuario")
                        .HasColumnType("text")
                        .HasColumnName("usuario");

                    b.HasKey("Id")
                        .HasName("pk_t_empleado");

                    b.ToTable("t_empleado");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            NombreEmpleado = "Luis Alberto del Parana",
                            Password = "secret",
                            Rol = 2,
                            Usuario = "luis"
                        },
                        new
                        {
                            Id = 2,
                            NombreEmpleado = "Gabriel Casccia",
                            Password = "secret",
                            Rol = 2,
                            Usuario = "gabriel"
                        },
                        new
                        {
                            Id = 3,
                            NombreEmpleado = "Augusto Roa Bastos",
                            Password = "secret",
                            Rol = 2,
                            Usuario = "augusto"
                        },
                        new
                        {
                            Id = 4,
                            NombreEmpleado = "Bertha Rojas",
                            Password = "secret",
                            Rol = 2,
                            Usuario = "bertha"
                        },
                        new
                        {
                            Id = 5,
                            NombreEmpleado = "Juan Pueblo",
                            Password = "secret",
                            Rol = 2,
                            Usuario = "juan"
                        },
                        new
                        {
                            Id = 6,
                            NombreEmpleado = "Francisco Russo",
                            Password = "secret",
                            Rol = 2,
                            Usuario = "francisco"
                        },
                        new
                        {
                            Id = 7,
                            NombreEmpleado = "Elvis Presley",
                            Password = "secret",
                            Rol = 1,
                            Usuario = "elvis"
                        });
                });

            modelBuilder.Entity("GestionReciboSalario.API.Entities.ReciboSalario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<double>("BonificacionFamiliar")
                        .HasColumnType("double precision")
                        .HasColumnName("bonificacion_familiar");

                    b.Property<int>("EmpleadoId")
                        .HasColumnType("integer")
                        .HasColumnName("empleado_id");

                    b.Property<DateTimeOffset>("Fecha")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("fecha");

                    b.Property<bool>("FirmaEmpleado")
                        .HasColumnType("boolean")
                        .HasColumnName("firma_empleado");

                    b.Property<bool>("FirmaGerente")
                        .HasColumnType("boolean")
                        .HasColumnName("firma_gerente");

                    b.Property<string>("FirmaUrl")
                        .HasColumnType("text")
                        .HasColumnName("firma_url");

                    b.Property<int?>("GerenteId")
                        .HasColumnType("integer")
                        .HasColumnName("gerente_id");

                    b.Property<double>("MontoIPS")
                        .HasColumnType("double precision")
                        .HasColumnName("monto_ips");

                    b.Property<double>("MontoSalario")
                        .HasColumnType("double precision")
                        .HasColumnName("monto_salario");

                    b.HasKey("Id")
                        .HasName("pk_t_recibo_salario");

                    b.HasIndex("EmpleadoId")
                        .HasDatabaseName("ix_t_recibo_salario_empleado_id");

                    b.HasIndex("GerenteId")
                        .HasDatabaseName("ix_t_recibo_salario_gerente_id");

                    b.ToTable("t_recibo_salario");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BonificacionFamiliar = 115000.0,
                            EmpleadoId = 1,
                            Fecha = new DateTimeOffset(new DateTime(2021, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -4, 0, 0, 0)),
                            FirmaEmpleado = false,
                            FirmaGerente = false,
                            GerenteId = 7,
                            MontoIPS = 207000.0,
                            MontoSalario = 2300000.0
                        },
                        new
                        {
                            Id = 2,
                            BonificacionFamiliar = 130000.0,
                            EmpleadoId = 2,
                            Fecha = new DateTimeOffset(new DateTime(2021, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -4, 0, 0, 0)),
                            FirmaEmpleado = false,
                            FirmaGerente = false,
                            GerenteId = 7,
                            MontoIPS = 234000.0,
                            MontoSalario = 2600000.0
                        },
                        new
                        {
                            Id = 3,
                            BonificacionFamiliar = 140000.0,
                            EmpleadoId = 3,
                            Fecha = new DateTimeOffset(new DateTime(2021, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -4, 0, 0, 0)),
                            FirmaEmpleado = false,
                            FirmaGerente = false,
                            GerenteId = 7,
                            MontoIPS = 252000.0,
                            MontoSalario = 2800000.0
                        },
                        new
                        {
                            Id = 4,
                            BonificacionFamiliar = 135000.0,
                            EmpleadoId = 4,
                            Fecha = new DateTimeOffset(new DateTime(2021, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -4, 0, 0, 0)),
                            FirmaEmpleado = false,
                            FirmaGerente = false,
                            GerenteId = 7,
                            MontoIPS = 243000.0,
                            MontoSalario = 2700000.0
                        },
                        new
                        {
                            Id = 5,
                            BonificacionFamiliar = 135000.0,
                            EmpleadoId = 5,
                            Fecha = new DateTimeOffset(new DateTime(2021, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -4, 0, 0, 0)),
                            FirmaEmpleado = false,
                            FirmaGerente = false,
                            GerenteId = 7,
                            MontoIPS = 243000.0,
                            MontoSalario = 2700000.0
                        },
                        new
                        {
                            Id = 6,
                            BonificacionFamiliar = 120000.0,
                            EmpleadoId = 6,
                            Fecha = new DateTimeOffset(new DateTime(2021, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -4, 0, 0, 0)),
                            FirmaEmpleado = false,
                            FirmaGerente = false,
                            GerenteId = 7,
                            MontoIPS = 216000.0,
                            MontoSalario = 2400000.0
                        });
                });

            modelBuilder.Entity("GestionReciboSalario.API.Entities.ReciboSalario", b =>
                {
                    b.HasOne("GestionReciboSalario.API.Entities.Empleado", "Empleado")
                        .WithMany()
                        .HasForeignKey("EmpleadoId")
                        .HasConstraintName("fk_t_recibo_salario_t_empleado_empleado_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestionReciboSalario.API.Entities.Empleado", "Gerente")
                        .WithMany()
                        .HasForeignKey("GerenteId")
                        .HasConstraintName("fk_t_recibo_salario_t_empleado_gerente_id");

                    b.Navigation("Empleado");

                    b.Navigation("Gerente");
                });
#pragma warning restore 612, 618
        }
    }
}