namespace petTrackerApi.DTO
{
    public class TipoExamenDTO
    {
        public int TipoExamenId { get; set; }

        public string Nombre { get; set; } = null!;

        public string Codigo { get; set; } = null!;

        public DateTime CreadoAt { get; set; }

        public DateTime EditadoAt { get; set; }
    }
}
