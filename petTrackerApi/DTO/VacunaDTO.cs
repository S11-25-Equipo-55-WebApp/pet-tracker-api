namespace petTrackerApi.DTO
{
    public class VacunaDTO
    {
        public int VacunaId { get; set; }

        public string Codigo { get; set; } = null!;

        public DateOnly FechaAplicacion { get; set; }

        public DateOnly? FechaProxima { get; set; }

        public string? Notas { get; set; }

        public int MascotaId { get; set; }

        public int TipoVacunaId { get; set; }
    }
}
