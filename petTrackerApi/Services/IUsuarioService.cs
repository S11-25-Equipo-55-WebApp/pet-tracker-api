using petTrackerApi.DTO;

namespace petTrackerApi.Services
{
    public interface IUsuarioService
    {
        Task<IEnumerable<UsuarioDTO>> Get();
        Task<UsuarioDTO> GetById(int id);
        Task<(bool Exito, string Error, UsuarioDTO dto)> Registro(UsuarioRegistroDTO dto);
        Task<UsuarioDTO> Update(int id, UsuarioDTO dto);
        Task<bool> Delete(int id);
        Task<UsuarioLoginRespuestaDTO> Login(UsuarioLoginDTO dto);
        bool IsUniqueUsuario(string username);
        Task<(bool Exito, string Error)> CambiarPassword(int usuarioId, string passwordActual, string passwordNuevo);


    }
}
