using petTrackerApi.DTO;
using petTrackerApi.Model;

namespace petTrackerApi.Repository
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> Get();
        Task<Usuario> GetById(int id);
        Task<Usuario> GetByUserName(string username);
        Task<Usuario> Registro(Usuario usuario);
        Task<Usuario> Update(int id, Usuario usuario);
        Task<Usuario> Delete(int id);
        bool IsUniqueUsuario(string username);
        Task<Usuario> GetByIdEntity(int id);
        Task UpdatePassword(Usuario usuario);

    }
}
