using LogicaNegocio;
using LogicaNegocio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


namespace PruebaConexionMysql.Controllers
{
    [Authorize]
    public class PersonaController : Controller
    {
        ManejadorPersona Admin = new ManejadorPersona();

        [Authorize]
        public IActionResult Index()
        {
            IEnumerable<PersonaModel> lista = Admin.Consultar();
       
            ViewBag.autenticado = LoginController.autenticado;
            ViewBag.rol = LoginController.rolActivo;
            ViewBag.UserActivo = LoginController.UserActivo;
            if (LoginController.rolActivo != "Empleado")
            {
                return View(lista);
            }
            else {
                return RedirectToAction("Index","Home");
            }
           
        }

        [Authorize]
        public IActionResult Guardar(){

            ViewBag.autenticado = LoginController.autenticado;
            ViewBag.rol = LoginController.rolActivo;
            ViewBag.UserActivo = LoginController.UserActivo;
            return View();       
        }
        [Authorize]
        [HttpPost]
        public RedirectToActionResult Guardar(PersonaModel persona)
        {
            ViewBag.autenticado = LoginController.autenticado;
            ViewBag.rol = LoginController.rolActivo;
            ViewBag.UserActivo = LoginController.UserActivo;
            var respuesta = Admin.Guardar(persona);
            return RedirectToAction("Index");
        }


        [Authorize]
        public RedirectToActionResult Eliminar(string correo)
        {
            var respuesta = Admin.Eliminar(correo);

            return RedirectToAction("index");
        }

        [Authorize]
        public IActionResult Actualizar(string correo)
        {
            ViewBag.autenticado = LoginController.autenticado;
            ViewBag.rol = LoginController.rolActivo;
            ViewBag.UserActivo = LoginController.UserActivo;
            PersonaModel respuesta = Admin.ConsultarCorreoPersona(correo)[0];
            ViewBag.id = respuesta.idPersona;
            return View(respuesta);
        }

        [Authorize]
        public RedirectToActionResult ActualizarPersona(PersonaModel persona,int id)
        {
            var respuesta = Admin.Actualizar(persona);
            
            return RedirectToAction("index");
        }

    }
}
