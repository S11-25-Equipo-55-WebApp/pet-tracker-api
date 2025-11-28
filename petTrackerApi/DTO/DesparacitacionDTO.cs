namespace petTrackerApi.DTO
{
    public class DesparacitacionDTO
    {
        public int DesparacitacionId { get; set; }

        public string Codigo { get; set; } = null!;

        public DateTime? FechaAplicacion { get; set; }

        public DateTime? FechaProxima { get; set; }

        public string? Notas { get; set; }

        public int MascotaId { get; set; }

        public int TipoDesparacitacionId { get; set; }

        public DateTime CreadoAt { get; set; }

        public DateTime? EditadoAt { get; set; }
    }
}
