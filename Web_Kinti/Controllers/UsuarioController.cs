using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Web_Kinti.Models;
using Web_Kinti.Services.Interface;

namespace Web_Kinti.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuario _usuario;

        public UsuarioController(IUsuario usuario)
        {
            _usuario = usuario;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Registro()
        {
            return View();
        }

        public IActionResult Validar(Usuario usuario)
        {
            var objUsuario = _usuario.getValidarUsuario(usuario);

            if (objUsuario != null)
            {
                HttpContext.Session.SetString("sesionUsuario", JsonConvert.SerializeObject(objUsuario));

                if (objUsuario.IdRol == 1)
                {
                    return RedirectToAction("Index", "Admin");
                }
                else if (objUsuario.IdRol == 2)
                {
                    return RedirectToAction("Listar", "Cliente");
                }
            }
            return View("Index");
        }
    }
}
