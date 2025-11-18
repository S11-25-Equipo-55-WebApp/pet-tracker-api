using System.ComponentModel.DataAnnotations;

namespace petTrackerApi.DTO
{
    public class UsuarioDTO
    {
        public int UsuarioId { get; set; }
        
        public string UserName { get; set; }
        
        public string Nombre { get; set; }
        
        public string Email { get; set; }
    }
}
