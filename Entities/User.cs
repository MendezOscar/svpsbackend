namespace svpsbackend.Entities
{
    public class User
    {
        public int UsuarioId { get; set; }
        public string Username { get; set; }
        public string Clave { get; set; }
        public string Tipo { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}