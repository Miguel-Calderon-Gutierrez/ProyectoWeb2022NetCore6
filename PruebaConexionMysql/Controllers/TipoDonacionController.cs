using AccesoDatos;
using LogicaNegocio;
using LogicaNegocio.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace PruebaConexionMysql.Controllers
{
    [Authorize]
    public class TipoDonacionController : Controller
    {
        // GET: TipoDonacionController


        public static bool autenticado = LoginController.autenticado;

        ManejadorTipoDonacion Admin = new ManejadorTipoDonacion();

        public List<UnidadModel> Unidades = new List<UnidadModel>();


        public IActionResult Index()
        {
            Unidades = Admin.ConsultarUnidad();
            ViewBag.rol = LoginController.rolActivo;
            ViewBag.autenticado = LoginController.autenticado;
            ViewBag.UserActivo = LoginController.UserActivo;
            ViewBag.Unidades = Unidades;
            return View();
        }


        [HttpPost]
        public IActionResult Nuevo(TipoDonacionModel tipoDonar){
            Admin.Guardar(tipoDonar); 
            ViewBag.rol = LoginController.rolActivo;
            ViewBag.autenticado = LoginController.autenticado;
            ViewBag.UserActivo = LoginController.UserActivo;
            return RedirectToAction("Index");
        }    
    }
}
