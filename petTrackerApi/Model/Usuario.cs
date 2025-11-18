using System.ComponentModel.DataAnnotations;

namespace petTrackerApi.Model
{
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Nombre {  get; set; }
        [Required]
        public string Email { get; set; }
        //[Required]
        public string Password { get; set; }
    }
}
