using Web_Kinti.Models;
using Web_Kinti.Services.Interface;

namespace Web_Kinti.Services.Repository
{
    public class UsuarioRepository : IUsuario
    {
        private BdRestaurant bd = new BdRestaurant();
        public Usuario getValidarUsuario(Usuario usuario)
        {
            var obj = (from tusuario in bd.Usuarios
                       where tusuario.Nombre == usuario.Nombre &&
                       tusuario.Clave == usuario.Clave
                       select tusuario).FirstOrDefault();
            return obj;
        }
    }
}
