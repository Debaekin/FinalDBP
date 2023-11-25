using Web_Kinti.Models;
using Web_Kinti.Services.Interface;

namespace Web_Kinti.Services.Repository
{
    public class ComidaRepository : IComida
    {
        private BdRestaurant bd = new BdRestaurant();

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
    }
}

