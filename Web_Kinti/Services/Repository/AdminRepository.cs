using Web_Kinti.Models;
using Web_Kinti.Services.Interface;

namespace Web_Kinti.Services.Repository
{
    public class AdminRepository : IAdmin, IComida
    {
        //nuevo objeto
        private BdRestaurant bd = new BdRestaurant();

        public void Add(Usuario usuario)
        {
            try
            {
                bd.Usuarios.Add(usuario);//insert into<tabla>values(datos)
                bd.SaveChanges();//Actualiza la bd
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Add(Comidum comida)
        {
            try
            {
                bd.Comida.Add(comida);//insert into<tabla>values(datos)
                bd.SaveChanges();//Actualiza la bd
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            };
        }

        public void Delete(int id)
        {
            var obj = (from tusuario in bd.Usuarios
                       where tusuario.IdUsuario == id
                       select tusuario).Single();

            bd.Usuarios.Remove(obj);
            bd.SaveChanges();
        }

        public void DeleteCo(int id)
        {
            var obj = (from tcomida in bd.Comida
                       where tcomida.IdComida == id
                       select tcomida).Single();

            bd.Comida.Remove(obj);
            bd.SaveChanges(); ;
        }

        public IEnumerable<Comidum> GetAllComidas()
        {
            return bd.Comida;
        }

        public Comidum GetComida(int id)
        {
            var obj = (from tcomida in bd.Comida
                       where tcomida.IdComida == id
                       select tcomida).Single();
            return obj;
        }

        public Comidum GetComidum(int id)
        {
            return (from tcomida in bd.Comida
                    where tcomida.IdComida == id
                    select tcomida).Single();

        }

        public Usuario GetUsuario(int id)
        {
            var obj = (from tusuario in bd.Usuarios
                       where tusuario.IdUsuario == id
                       select tusuario).Single();
            return obj;
        }

        public void Update(Usuario usuarioConDatosModificados)
        {
            var objModificado = (from tusuario in bd.Usuarios
                                 where tusuario.IdUsuario == usuarioConDatosModificados.IdUsuario
                                 select tusuario).FirstOrDefault();
            if (objModificado != null)
            {
                objModificado.IdUsuario = usuarioConDatosModificados.IdUsuario;
                objModificado.Nombre = usuarioConDatosModificados.Nombre;
                objModificado.Apellido = usuarioConDatosModificados.Apellido;
                objModificado.Telefono = usuarioConDatosModificados.Telefono;
                objModificado.UrlFoto = usuarioConDatosModificados.UrlFoto;
                objModificado.IdRol = usuarioConDatosModificados.IdRol;

                bd.SaveChanges();

            }
        }

        public void Update(Comidum comidaConDatosModificados)
        {
            var objModificado = (from tcomida in bd.Comida
                                 where tcomida.IdComida == comidaConDatosModificados.IdComida
                                 select tcomida).FirstOrDefault();
            if (objModificado != null)
            {
                objModificado.IdComida = comidaConDatosModificados.IdComida;
                objModificado.CodigoBarra = comidaConDatosModificados.CodigoBarra;
                objModificado.Descripcion = comidaConDatosModificados.Descripcion;
                objModificado.IdCategoria = comidaConDatosModificados.IdCategoria;
                objModificado.UrlFoto = comidaConDatosModificados.UrlFoto;
                objModificado.Precio = comidaConDatosModificados.Precio;

                bd.SaveChanges();

            }
        }

        IEnumerable<Usuario> IAdmin.GetAllUsuarios()
        {

            return bd.Usuarios;

        }
    }
}
