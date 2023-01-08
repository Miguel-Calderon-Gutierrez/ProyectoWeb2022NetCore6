using LogicaNegocio;
using Microsoft.AspNetCore.Mvc;
using PruebaConexionMysql.Models;
using System.Diagnostics;

using Microsoft.AspNetCore.Authorization;
using LogicaNegocio.Models;

namespace PruebaConexionMysql.Controllers
{

    public class HomeController : Controller
    {
        ManejadorHome admin = new ManejadorHome();
        private readonly ILogger<HomeController> _logger;
        public static bool autenticado = LoginController.autenticado;
        public static string rolActivo = LoginController.rolActivo;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            FundacionModel fundacion = fundacion = admin.ConsultarFundacion()[0];
            ViewBag.autenticado = LoginController.autenticado;
            ViewBag.rol = LoginController.rolActivo;
            ViewBag.UserActivo = LoginController.UserActivo;
            return View(fundacion);
        }

        public IActionResult Buscador(string palabra="")
        {
            ManejadorEvento adminEvento = new ManejadorEvento();

            if (palabra == null) {
                palabra = "";
            }

            var eventos = adminEvento.ConsultarEventosBuscador(palabra);
            ManejadorPuesto manejadorPuesto = new ManejadorPuesto();

            List<List<PuestoModel>> listaPuestos = new List<List<PuestoModel>>();
            foreach (var evento in eventos) {
                listaPuestos.Add(manejadorPuesto.ConsultarPuestosEvento(evento.ID_EVENTO));
            }

            ViewBag.autenticado = LoginController.autenticado;
            ViewBag.rol = LoginController.rolActivo;
            ViewBag.UserActivo = LoginController.UserActivo;
            ViewBag.puestos = listaPuestos;

            return View(eventos);
        }

        [Authorize]
        public IActionResult Privacy()
        {  
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}