namespace petTrackerApi.DTO
{
    public class MedicacionDTO
    {
        public int MedicacionId { get; set; }

        public string Codigo { get; set; } = null!;

        public string Nombre { get; set; } = null!;

        public int Frecuencia { get; set; }

        public string? Descripcion { get; set; }

        public int ConsultaId { get; set; }

        public int TipoMedicacionId { get; set; }
    }
}
