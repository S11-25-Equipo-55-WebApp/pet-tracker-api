namespace petTrackerApi.DTO
{
    public class TipoEventoDTO
    {
        public int TipoEventoId { get; set; }

        public string Nombre { get; set; } = null!;

        public string Codigo { get; set; } = null!;

        public string Descripcion { get; set; } = null!;

        public DateTime CreadoAt { get; set; }

        public DateTime EditadoAt { get; set; }
    }
}
