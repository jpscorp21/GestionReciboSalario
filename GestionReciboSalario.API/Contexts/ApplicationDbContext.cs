using System;
using System.Collections.Generic;
using GestionReciboSalario.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestionReciboSalario.API.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options
          ) : base(options)
        { }

        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<ReciboSalario> ReciboSalarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Empleado>()
                .Property(c => c.Rol)
                .HasConversion<int>();

            var empleados = new List<Empleado> {
              new Empleado {
                Id = 1,
                NombreEmpleado = "Luis Alberto del Parana",
                Usuario = "luis",
                Password = "secret",
                Rol = Rol.Empleado
              },
              new Empleado {
                Id = 2,
                NombreEmpleado = "Gabriel Casccia",
                Usuario = "gabriel",
                Password = "secret",
                Rol = Rol.Empleado
              },
              new Empleado {
                Id = 3,
                NombreEmpleado = "Augusto Roa Bastos",
                Usuario = "augusto",
                Password = "secret",
                Rol = Rol.Empleado
              },
              new Empleado {
                Id = 4,
                NombreEmpleado = "Bertha Rojas",
                Usuario = "bertha",
                Password = "secret",
                Rol = Rol.Empleado
              },
              new Empleado {
                Id = 5,
                NombreEmpleado = "Juan Pueblo",
                Usuario = "juan",
                Password = "secret",
                Rol = Rol.Empleado
              },
              new Empleado {
                Id = 6,
                NombreEmpleado = "Francisco Russo",
                Usuario = "francisco",
                Password = "secret",
                Rol = Rol.Empleado
              },
              new Empleado {
                Id = 7,
                NombreEmpleado = "Elvis Presley",
                Usuario = "elvis",
                Password = "secret",
                Rol = Rol.Gerente
              },
            };

            var reciboSalarios = new List<ReciboSalario> {
              new ReciboSalario {
                Id = 1,
                EmpleadoId = 1,
                GerenteId = 7,
                MontoIPS = 207000,
                MontoSalario = 2300000,
                BonificacionFamiliar = 115000,
                Fecha = new DateTime(2021, 7, 30),
              },
              new ReciboSalario {
                Id = 2,
                EmpleadoId = 2,
                GerenteId = 7,
                MontoIPS = 234000,
                MontoSalario = 2600000,
                BonificacionFamiliar = 130000,
                Fecha = new DateTime(2021, 7, 30),
              },
              new ReciboSalario {
                Id = 3,
                EmpleadoId = 3,
                GerenteId = 7,
                MontoIPS = 252000,
                MontoSalario = 2800000,
                BonificacionFamiliar = 140000,
                Fecha = new DateTime(2021, 7, 30),
              },
              new ReciboSalario {
                Id = 4,
                EmpleadoId = 4,
                GerenteId = 7,
                MontoIPS = 243000,
                MontoSalario = 2700000,
                BonificacionFamiliar = 135000,
                Fecha = new DateTime(2021, 7, 30),
              },
              new ReciboSalario {
                Id = 5,
                EmpleadoId = 5,
                GerenteId = 7,
                MontoIPS = 243000,
                MontoSalario = 2700000,
                BonificacionFamiliar = 135000,
                Fecha = new DateTime(2021, 7, 30),
              },
              new ReciboSalario {
                Id = 6,
                EmpleadoId = 6,
                GerenteId = 7,
                MontoIPS = 216000,
                MontoSalario = 2400000,
                BonificacionFamiliar = 120000,
                Fecha = new DateTime(2021, 7, 30),
              },
            };

            foreach (var item in empleados)
            {
                modelBuilder.Entity<Empleado>()
                .HasData(item);
            }

            foreach (var item in reciboSalarios)
            {
                modelBuilder.Entity<ReciboSalario>()
                .HasData(item);
            }

        }
    }
}
