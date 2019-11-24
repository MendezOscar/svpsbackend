using System;
using System.Collections.Generic;

namespace svpsbackend.Models
{
    public partial class Planilla
    {
        public int PanillaId { get; set; }
        public DateTime? Fecha { get; set; }
        public double? Salario { get; set; }
        public int? Empleadoid { get; set; }
    }
}
