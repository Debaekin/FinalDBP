using Microsoft.AspNetCore.Mvc;
using Web_Kinti.Models;
using Web_Kinti.Services.Interface;

namespace Web_Kinti.Controllers
{
    public class TemporalVentaController : Controller
    {
        private readonly ITemporalVenta _temporalVenta;
        public TemporalVentaController (ITemporalVenta temporal)
        {
            _temporalVenta = temporal;
        }
        public IActionResult Index(TemporalVenta temporal)
        {
            _temporalVenta.add(temporal);
            return RedirectToAction("Listar", "Cliente");
        }
        public IActionResult VerCarrito()
        {
            return View(_temporalVenta.GetAllTemporySale());
        }
    }
}
