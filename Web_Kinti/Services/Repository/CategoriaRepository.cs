using Web_Kinti.Models;
using Web_Kinti.Services.Interface;

namespace Web_Kinti.Services.Repository
{
    public class CategoriaRepository : ICategoria
    {
        private BdRestaurant bd = new BdRestaurant();

        public IEnumerable<Categorium> GetAllCategorias()
        {
            return bd.Categoria.ToList();
        }
    }
}
