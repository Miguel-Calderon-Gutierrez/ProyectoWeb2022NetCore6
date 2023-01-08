using LogicaNegocio;
using LogicaNegocio.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PruebaConexionMysql.Controllers
{
    [Authorize]
    public class PuestosController : Controller
    {

        ManejadorPuesto Admin = new ManejadorPuesto();

        public List<PuestoEventoModel> Eventos = new List<PuestoEventoModel>();


        // GET: PuestosController
        public IActionResult Index()
        {

            IEnumerable<PuestoModel> lista = Admin.ConsultarPuestos();
            ViewBag.rol = LoginController.rolActivo;
            ViewBag.autenticado = LoginController.autenticado;
            ViewBag.UserActivo = LoginController.UserActivo;
            return View(lista);
        }

        public IActionResult Nuevo()
        {
            Eventos = Admin.ConsultarEvento();
            ViewBag.Eventos = Eventos;
            ViewBag.rol = LoginController.rolActivo;
            ViewBag.autenticado = LoginController.autenticado;
            ViewBag.UserActivo = LoginController.UserActivo;
            return View();
        }

        [HttpPost]

        public IActionResult Guardar(PuestoModel puesto)
        {
            Admin.Guardar(puesto);
            ViewBag.rol = LoginController.rolActivo;
            ViewBag.autenticado = LoginController.autenticado;
            ViewBag.UserActivo = LoginController.UserActivo;
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Actualizar(PuestoModel model)
        {
            bool respuesta = Admin.Actualizar(model);
            ViewBag.rol = LoginController.rolActivo;
            ViewBag.autenticado = LoginController.autenticado;
            ViewBag.UserActivo = LoginController.UserActivo;
            return RedirectToAction("Index");
        }

        public ActionResult Actualizar(int ID_PUESTO_DONACION)
        {
            Eventos = Admin.ConsultarEvento();
            ViewBag.Eventos = Eventos;
            PuestoModel modelo = Admin.ConsultarId(ID_PUESTO_DONACION)[0];
            ViewBag.rol = LoginController.rolActivo;
            ViewBag.autenticado = LoginController.autenticado;
            ViewBag.UserActivo = LoginController.UserActivo;
            return View(modelo);

        }
    }
}
