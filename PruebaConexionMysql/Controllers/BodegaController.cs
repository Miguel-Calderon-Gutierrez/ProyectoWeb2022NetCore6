using LogicaNegocio;
using LogicaNegocio.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PruebaConexionMysql.Controllers
{
    [Authorize]
    public class BodegaController : Controller
    {

        // GET: BodegaController
        public static bool autenticado = LoginController.autenticado;

        ManejadorBodega Admin = new ManejadorBodega();

        public IActionResult Index()
        {
            IEnumerable<BodegaModel> lista = Admin.Consultar();
            ViewBag.autenticado = LoginController.autenticado;
            ViewBag.rol = LoginController.rolActivo;
            ViewBag.UserActivo = LoginController.UserActivo;
            return View(lista);
        }
    }
}
