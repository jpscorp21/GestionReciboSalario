using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionReciboSalario.API.Entities
{
    [Table(name: "t_recibo_salario")]
    public class ReciboSalario
    {
        public int Id { get; set; }
        [ForeignKey("EmpleadoId")]
        public Empleado Empleado { get; set; }
        public int EmpleadoId { get; set; }
        [ForeignKey("GerenteId")]
        public Empleado Gerente { get; set; }
        public int? GerenteId { get; set; }
        public double MontoSalario { get; set; }
        public double MontoIPS { get; set; }
        public DateTimeOffset Fecha { get; set; }
        public double BonificacionFamiliar { get; set; }
        public bool FirmaEmpleado { get; set; } = false;
        public bool FirmaGerente { get; set; } = false;
        public string FirmaUrl {get; set;}
    }
}