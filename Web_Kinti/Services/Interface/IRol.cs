using Web_Kinti.Models;

namespace Web_Kinti.Services.Interface
{
    public interface IRol
    {
        IEnumerable<Rol> GetAllRols();
        
        void Add(Rol rol);
        void Update(Rol rol);
        void Delete(int id);
        Rol GetRol(int id);
    }
}
