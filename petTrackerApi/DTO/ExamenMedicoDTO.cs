namespace petTrackerApi.DTO
{
    public class ExamenMedicoDTO
    {
        public int ExamenId { get; set; }

        public string Codigo { get; set; } = null!;

        public DateOnly FechaExamen { get; set; }

        public string? Resultado { get; set; }

        public int ConsultaId { get; set; }

        public int TipoExamenId { get; set; }
    }
}
