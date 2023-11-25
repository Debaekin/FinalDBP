using Web_Kinti.Models;

namespace Web_Kinti.Services.Interface
{
    public interface IReserva
    {
        IEnumerable<Reservacion> GetAllReservas();
        void Add(Reservacion reserva);
        void Update(Reservacion reserva);
        void Delete(int id);
        Reservacion GetReserva(int id);
    }
}

