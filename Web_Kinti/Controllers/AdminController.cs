using Microsoft.AspNetCore.Mvc;
using Web_Kinti.Models;
using Web_Kinti.Services.Interface;

namespace Web_Kinti.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdmin iadmin;
        private readonly IComida icomida;
        private readonly ICategoria icategoria;
        private readonly IRol irol;
        private readonly IReserva ireserva;

        public AdminController(IAdmin iadminobj, IComida icomida, ICategoria icategoria, IRol irol, IReserva ireserva)
        {
            iadmin = iadminobj;
            this.icomida = icomida;
            this.icategoria = icategoria;
            this.irol = irol;
            this.ireserva = ireserva;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("ad/registraru")]
        [Route("admin/registraru")]//
        public IActionResult Registrarse()

        {
            ViewBag.ListaDeRols = irol.GetAllRols();

            return View();
        }

        [Route("ad/listarusu")]
        [Route("admin/listarusu")]//
        public IActionResult Listar()
        {//llamando al objeto creado
            return View(iadmin.GetAllUsuarios());
        }
        public IActionResult Registro(Usuario usuario)//
        {
            iadmin.Add(usuario);
            return RedirectToAction("Listar");
        }

        [Route("Admin/Edit/{id}")]
        public IActionResult Edit(int id)
        {
            ViewBag.ListaDeRols = irol.GetAllRols();

            return View(iadmin.GetUsuario(id));
        }

        [Route("Admin/Delete/{id}")]
        public IActionResult Delete(int id)//
        {
            iadmin.Delete(id);
            return RedirectToAction("Listar");
        }
        public IActionResult EditDetails(Usuario usuario)//
        {
            iadmin.Update(usuario);
            return RedirectToAction("Listar");
        }

        [Route("admin/registrarpro")]//
        [Route("ad/registrarpro")]
        public IActionResult Registrarpro()
        {
            ViewBag.ListaDeCategorias = icategoria.GetAllCategorias();
            return View();
        }
        public IActionResult Registroco(Comidum comida)//
        {
            icomida.Add(comida);
            return RedirectToAction("Listarpro");
        }

        [Route("ad/listarpro")]
        [Route("admin/listarpro")]//
        public IActionResult Listarpro()
        {//llamando al objeto creado
            return View(icomida.GetAllComidas());
        }

        [Route("Admin/EditCo/{id}")]//
        public IActionResult Editco(int id)

        {
            ViewBag.ListaDeCategorias = icategoria.GetAllCategorias();
            return View(icomida.GetComida(id));
        }

        [Route("Admin/DeleteCo/{id}")]//
        public IActionResult DeleteCo(int id)
        {
            icomida.DeleteCo(id);
            return RedirectToAction("Listarpro");
        }

        public IActionResult EditDetailsCo(Comidum comidum)
        {
            icomida.Update(comidum);
            return RedirectToAction("Listarpro");
        }

        /*RESERVAS*/
        [Route("admin/registrarre")]
        [Route("ad/registrarre")]
        public IActionResult Registrarre()
        {
            ViewBag.ListaDeUsuarios = iadmin.GetAllUsuarios();
            return View();
        }
        public IActionResult Registrore(Reservacion reserva)
        {
            ireserva.Add(reserva);
            return RedirectToAction("Listarre");
        }

        [Route("ad/listarre")]
        [Route("admin/listarre")]
        public IActionResult Listarre()
        {
            return View(ireserva.GetAllReservas());
        }

        [Route("admin/EditRe/{id}")] //Editar reserva
        public IActionResult Editre(int id)
        {
            ViewBag.ListaDeUsuarios = iadmin.GetAllUsuarios();
            return View(ireserva.GetReserva(id));
        }

        [Route("admin/DeleteRe/{id}")] //Eliminar reserva
        public IActionResult Deletere(int id)
        {
            ireserva.Delete(id);
            return RedirectToAction("Listarre");
        }
        public IActionResult EditDetailsRe(Reservacion reservacion)
        {
            ireserva.Update(reservacion);
            return RedirectToAction("Listarre");
        }

        [Route("ad/listarro")]
        [Route("admin/listarro")]
        public IActionResult Listarro()
        {//llamando al objeto creado
            return View(irol.GetAllRols());
        }

        [Route("admin/EditRo/{id}")] //Editar rol
        public IActionResult Editro(int id)
        {
            return View(irol.GetRol(id));
        }

        [Route("admin/DeleteRo/{id}")] //Eliminar rol
        public IActionResult Deletero(int id)
        {
            irol.Delete(id);
            return RedirectToAction("Listarro");
        }
        public IActionResult EditDetailsRo(Rol rol)
        {
            irol.Update(rol);
            return RedirectToAction("Listarro");
        }
        [Route("admin/registrarro")]
        [Route("ad/registrarro")]
        public IActionResult Registrarro()
        {
            return View();
        }
        public IActionResult Registroro(Rol rol)
        {
            irol.Add(rol);
            return RedirectToAction("Listarro");
        }
    }
}
