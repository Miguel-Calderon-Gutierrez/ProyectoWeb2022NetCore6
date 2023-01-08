using LogicaNegocio;
using LogicaNegocio.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PruebaConexionMysql.Controllers
{
    [Authorize]
    public class FundacionController : Controller
    {
        // GET: Fundacion

        ManejadorFundacion admin = new ManejadorFundacion();

        public ActionResult Index()
        {
            FundacionModel informacion2 = admin.ConsultarFundacion()[0];
            ViewBag.autenticado = LoginController.autenticado;
            ViewBag.rol = LoginController.rolActivo;
            ViewBag.UserActivo = LoginController.UserActivo;
            return View(informacion2);
        }

        [HttpPost]
        public IActionResult Actualizar(FundacionModel informacion)
        {
            admin.ActualizarFundacion(informacion);
            return RedirectToAction("Index", "Home");
        }
    }
}
