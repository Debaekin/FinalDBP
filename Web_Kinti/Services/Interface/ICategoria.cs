using Web_Kinti.Models;

namespace Web_Kinti.Services.Interface
{
    public interface ICategoria
    {
        IEnumerable<Categorium> GetAllCategorias();
    }
}
