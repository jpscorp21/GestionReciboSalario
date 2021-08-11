using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionReciboSalario.API.Entities
{
    [Table(name: "t_empleado")]
    public class Empleado
    {
        public int Id { get; set; }
        public string NombreEmpleado { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public Rol Rol { get; set; }
    }

    public enum Rol
    {
        Gerente = 1,
        Empleado = 2
    }
}