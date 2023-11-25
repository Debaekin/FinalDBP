using Microsoft.AspNetCore.Mvc;
using Web_Kinti.Services.Interface;

namespace Web_Kinti.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IComida objComida;
        public ClienteController(IComida objComida)
        {
            this.objComida = objComida;
        }
        /*
        public IActionResult Index()
        {
            return View();
        }*/

        [Route("TemporalVenta/Listar")]
        [Route("Cliente/listar")]
        public IActionResult Listar()
        {
            return View(objComida.GetAllComidas());
        }

        [Route("cliente/Comprar/{id}")]
        public IActionResult Comprar(int id)
        {
            ViewData["codigo"] = objComida.GetComida(id).IdComida;
            ViewData["nombre"] = objComida.GetComida(id).CodigoBarra;
            ViewData["precio"] = objComida.GetComida(id).Precio;

            return View();
        }
    }
}
