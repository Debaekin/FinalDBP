using Web_Kinti.Models;
using Web_Kinti.Services.Interface;

namespace Web_Kinti.Services.Repository
{
    public class RolRepository : IRol
    {
        private BdRestaurant bd = new BdRestaurant();
        public void Add(Rol rol)
        {
            try
            {
                bd.Rols.Add(rol);
                bd.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        public void Delete(int id)
        {
            var obj = (from trol in bd.Rols
                       where trol.IdRol == id
                       select trol).Single();

            bd.Rols.Remove(obj);
            bd.SaveChanges();
        }

        public IEnumerable<Rol> GetAllRols()
        {
            return bd.Rols.ToList();
        }

        public Rol GetRol(int id)
        {
            var obj = (from trol in bd.Rols
                       where trol.IdRol == id
                       select trol).Single();
            return obj;
        }

        public void Update(Rol rolConDatosModificados)
        {
            var objModificado = (from trol in bd.Rols
                                 where trol.IdRol == rolConDatosModificados.IdRol
                                 select trol).FirstOrDefault();
            if (objModificado != null)
            {
                objModificado.IdRol = rolConDatosModificados.IdRol;
                objModificado.Nombre = rolConDatosModificados.Nombre;

                bd.SaveChanges();
            }
        }

    }
}
