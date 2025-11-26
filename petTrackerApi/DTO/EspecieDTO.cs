namespace petTrackerApi.DTO
{
    public class EspecieDTO
    {

        public int MascotaId { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int EspecieId { get; set; }
        public int RazaId { get; set; }
        public int? FotoMascotaId { get; set; }
        public int UsuarioId { get; set; }
        public DateTime CreadoAt { get; set; }
        public DateTime EditadoAt { get; set; }
    }
}
