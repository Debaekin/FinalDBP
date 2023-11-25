using Web_Kinti.Models;

namespace Web_Kinti.Services.Interface
{
    public interface IComida
    {
        IEnumerable<Comidum> GetAllComidas();
        void Add(Comidum comida);
        void Update(Comidum comida);
        void DeleteCo(int id);
        Comidum GetComida(int id);
        Comidum GetComidum(int id);
    }
}
