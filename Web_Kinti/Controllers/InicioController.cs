using Microsoft.AspNetCore.Mvc;

namespace Web_Kinti.Controllers
{
    public class InicioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
