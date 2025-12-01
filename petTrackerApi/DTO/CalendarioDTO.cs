namespace petTrackerApi.DTO
{
    public class CalendarioDTO
    {
        public int CalendarioId { get; set; }

        public string Codigo { get; set; } = null!;

        public string Titulo { get; set; } = null!;

        public DateTime FechaEvento { get; set; }

        public string? Notas { get; set; }

        public int UsuarioId { get; set; }

        public int MascotaId { get; set; }

        public int? TipoEventoId { get; set; }

        public DateTime CreadoAt { get; set; }

        public DateTime? EditadoAt { get; set; }
    }
}
