using System;
using System.Collections.Generic;

namespace svpsbackend.Models
{
    public partial class Empleado
    {
        public int EmpleadoId { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Sexo { get; set; }
        public double? Salario { get; set; }
        public string Direccion { get; set; }
        public int? DepartamentoId { get; set; }
        public int? CargoId { get; set; }
        public int? UserId { get; set; }
    }
}
