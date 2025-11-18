using System.ComponentModel.DataAnnotations;

namespace petTrackerApi.DTO
{
    public class UsuarioLoginDTO
    {
        [Required(ErrorMessage = "El usuario es requerido")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "El password es requerido")]
        public string Password { get; set; }
       
    }
}
