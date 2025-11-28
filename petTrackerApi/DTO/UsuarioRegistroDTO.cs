namespace petTrackerApi.DTO
{
    public class UsuarioRegistroDTO
    {
        public int UsuarioId { get; set; }

        public string UserName { get; set; }

        public string Nombre { get; set; }

        public string? Apellido { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string? Telefono { get; set; }
        public DateTime CreadoAt { get; set; }

        public DateTime? EditadoAt { get; set; }
    }
}
