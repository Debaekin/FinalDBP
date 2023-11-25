using Web_Kinti.Models;

namespace Web_Kinti.Services.Interface
{
    public interface IAdmin
    {
        IEnumerable<Usuario> GetAllUsuarios();
        void Add(Usuario usuario);
        void Update(Usuario usuario);
        void Delete(int id);
        Usuario GetUsuario(int id);
    }
}
