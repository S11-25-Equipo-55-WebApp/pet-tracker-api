namespace petTrackerApi.Model
{
    public class Especie
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public DateTime CreadoAt { get; set; } = DateTime.Now;
        public DateTime EditadoAt { get; set; }
    }
}
