namespace petTrackerApi.Model
{
    public class Mascota
    {
        public int Id { get; set; }
        public string FechaNac { get; set; }
        public DateTime CreadoAt { get; set; } = DateTime.Now;
        public DateTime EditadoAt { get; set; }
        // Foreign Keys
        public int EspecieId { get; set; }
        public Especie Especie { get; set; } = null!;
        public int RazaId { get; set; }
        public Raza Raza { get; set; } = null!;
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; } = null!;
    }
}
