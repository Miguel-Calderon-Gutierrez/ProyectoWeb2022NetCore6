using LogicaNegocio;
using LogicaNegocio.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PruebaConexionMysql.Controllers
{
    [Authorize]
    public class EventoController : Controller
    {
        // GET: EventoController
        ManejadorEvento admin = new ManejadorEvento();
        public ActionResult Index()
        {
            List<EventoModel> lista = admin.Consultar();
            ViewBag.autenticado = LoginController.autenticado;
            ViewBag.rol = LoginController.rolActivo;
            ViewBag.UserActivo = LoginController.UserActivo;
            return View(lista);
        }

        public IActionResult Guardar()
        {

            ViewBag.rol = LoginController.rolActivo;
            ViewBag.autenticado = LoginController.autenticado;
            ViewBag.UserActivo = LoginController.UserActivo;
            return View();
        }

        public IActionResult Actualizar(int ID_EVENTO)
        {
            EventoModel evento = admin.ConsultarIdEvento(ID_EVENTO)[0];
            ViewBag.rol = LoginController.rolActivo;
            ViewBag.autenticado = LoginController.autenticado;
            ViewBag.UserActivo = LoginController.UserActivo;
            return View(evento);
        }

        [HttpPost]
        public IActionResult Actualizar(EventoModel eventico)
        {
            bool respuesta = admin.Actualizar(eventico);
            ViewBag.rol = LoginController.rolActivo;
            ViewBag.autenticado = LoginController.autenticado;
            ViewBag.UserActivo = LoginController.UserActivo;
            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult Guardar(EventoModel Eventico)
        {
            ViewBag.rol = LoginController.rolActivo;
            ViewBag.autenticado = LoginController.autenticado;
            ViewBag.UserActivo = LoginController.UserActivo;
            admin.Guardar(Eventico);
            return RedirectToAction("Index");
        }

        public IActionResult CambioEstado(int ID_EVENTO) {
            admin.ActualizarEstado(ID_EVENTO);
            return RedirectToAction("Index");
        }

    }
}