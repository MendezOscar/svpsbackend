using System;
using System.Collections.Generic;

namespace svpsbackend.Models
{
    public partial class Bono
    {
        public int BonoId { get; set; }
        public string Nombre { get; set; }
        public double? Monto { get; set; }
        public int? PlanillaId { get; set; }
        public int? EmpleadoId { get; set; }
    }
}
