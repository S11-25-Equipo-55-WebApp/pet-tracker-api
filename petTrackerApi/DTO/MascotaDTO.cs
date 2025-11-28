using petTrackerApi.Model;

namespace petTrackerApi.DTO
{
    public class MascotaDTO
    {
        public int MascotaId { get; set; }
        public string Nombre { get; set; } = null!;

        public string? Codigo { get; set; } = null!;

        public DateOnly? FechaNacimiento { get; set; }

        public int EspecieId { get; set; }

        public int RazaId { get; set; }

        public string FotoMascota { get; set; }

        public int UsuarioId { get; set; }
    }
}
