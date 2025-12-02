namespace petTrackerApi.DTO
{
    public class ControlPesoDTO
    {
        public int ControlPesoId { get; set; }

        public string Codigo { get; set; } = null!;

        public int Peso { get; set; }

        public int UnidadMedidaId { get; set; }

        public string? Notas { get; set; }

        public int MascotaId { get; set; }
    }
}
