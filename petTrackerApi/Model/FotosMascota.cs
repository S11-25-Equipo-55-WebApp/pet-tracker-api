namespace petTrackerApi.Model
{
    public class FotosMascota
    {
        public int Id { get; set; }
        public string FotoUrl { get; set; }
        public string Descripcion { get; set; }
        public DateTime SubidaAt { get; set; } = DateTime.Now;
        // Foreign Key to Mascota
        public int MascotaId { get; set; }
        public Mascota Mascota { get; set; } = null!;
    }
}
