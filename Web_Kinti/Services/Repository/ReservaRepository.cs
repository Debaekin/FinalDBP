using Web_Kinti.Models;
using Web_Kinti.Services.Interface;

namespace Web_Kinti.Services.Repository
{
    public class ReservaRepository : IReserva
    {
        private BdRestaurant bd = new BdRestaurant();
        public void Add(Reservacion reserva)
        {
            try
            {
                bd.Reservacions.Add(reserva);
                bd.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Delete(int id)
        {
            var obj = (from treserva in bd.Reservacions
                       where treserva.IdReservacion == id
                       select treserva).Single();

            bd.Reservacions.Remove(obj);
            bd.SaveChanges();
        }

        public IEnumerable<Reservacion> GetAllReservas()
        {
            return bd.Reservacions;
        }

        public Reservacion GetReserva(int id)
        {
            var obj = (from treserva in bd.Reservacions
                       where treserva.IdReservacion == id
                       select treserva).Single();
            return obj;
        }

        public void Update(Reservacion reservaConDatosModificados)
        {
            var objModificado = (from treserva in bd.Reservacions
                                 where treserva.IdReservacion == reservaConDatosModificados.IdReservacion
                                 select treserva).FirstOrDefault();
            if (objModificado != null)
            {
                objModificado.IdReservacion = reservaConDatosModificados.IdReservacion;
                objModificado.IdUsuario = reservaConDatosModificados.IdUsuario;
                objModificado.Fecha = reservaConDatosModificados.Fecha;

                bd.SaveChanges();
            }
        }
    }
}
