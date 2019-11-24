using System;
using System.Collections.Generic;

namespace svpsbackend.Models
{
    public partial class Deduccion
    {
        public int DeduccionId { get; set; }
        public string Nombre { get; set; }
        public double? Monto { get; set; }
        public int? EmpleadoId { get; set; }
        public int? PlanillaId { get; set; }
    }
}
