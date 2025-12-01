namespace petTrackerApi.DTO
{
    public class EstadoRecordatorioDTO
    {
        public int EstadoId { get; set; }

        public string Nombre { get; set; } = null!;

        public string Codigo { get; set; } = null!;

        public DateTime CreadoAt { get; set; }

        public DateTime EditadoAt { get; set; }
    }
}
