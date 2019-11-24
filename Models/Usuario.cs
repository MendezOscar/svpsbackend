using System;
using System.Collections.Generic;

namespace svpsbackend.Models
{
    public partial class Usuario
    {
        public int UsuarioId { get; set; }
        public string Username { get; set; }
        public string Clave { get; set; }
        public string Tipo { get; set; }
    }
}
