namespace petTrackerApi.DTO
{
    public class ConsultaClinicaDTO
    {
        public int ConsultaClinicaId { get; set; }

        public string Codigo { get; set; } = null!;

        public DateTime FechaConsulta { get; set; }

        public string? Motivo { get; set; }

        public string? Diagnostico { get; set; }

        public string? Veterinario { get; set; }

        public string? Notas { get; set; }

        public int MascotaId { get; set; }
    }
}
