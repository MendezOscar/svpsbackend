using System;
using System.Collections.Generic;

namespace svpsbackend.Models
{
    public partial class Permisosxusuario
    {
        public int Permisoxusuario { get; set; }
        public int? PermisoId { get; set; }
        public int? UsuarioId { get; set; }
    }
}
