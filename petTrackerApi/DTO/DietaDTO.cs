namespace petTrackerApi.DTO
{
    public class DietaDTO
    {
        public int DietaId { get; set; }

        public string Codigo { get; set; } = null!;

        public int PorcionDia { get; set; }

        public string? Notas { get; set; }

        public int MascotaId { get; set; }

        public int TipoAlimentoId { get; set; }
        public int UnidadMedidaId { get; set; }
    }
}
