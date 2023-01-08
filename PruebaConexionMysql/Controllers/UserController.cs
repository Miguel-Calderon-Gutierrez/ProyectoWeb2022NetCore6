
using LogicaNegocio;
using LogicaNegocio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace PruebaConexionMysql.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        ManejadorUsuarios Admin = new ManejadorUsuarios();
        public static bool respuestaInsert = false;
        public static string nombreInsert = "";
        public static bool editado = false;
        public static string nombreEditado = "";
        public static bool eliminado = false;
        public static bool autenticado = LoginController.autenticado;

        public IActionResult Index()
        {
            IEnumerable<UserModel> lista = Admin.Consultar();         
            ViewBag.rol = LoginController.rolActivo;
            ViewBag.autenticado = LoginController.autenticado;
            ViewBag.UserActivo = LoginController.UserActivo;
            return View(lista);
        }

        public ActionResult Guardar()
        {
            ViewBag.rol = LoginController.rolActivo;
            ViewBag.autenticado = LoginController.autenticado;
            ViewBag.UserActivo = LoginController.UserActivo;
            ViewBag.Roles = Admin.ConsultarRolesDisponibles();
            ViewBag.Correos = Admin.ConsultarCorreosSinUsuario();
            return View();
        }

        [HttpPost]
        public ActionResult Guardar(UserModel model)
        {
            respuestaInsert = Admin.Guardar(model);

            return RedirectToAction("Index");
        }

        public ActionResult Actualizar(string nombreUser)
        {
            UserModel modelo = Admin.ConsultarUser(nombreUser)[0];
            ViewBag.rol = LoginController.rolActivo;
            ViewBag.autenticado = LoginController.autenticado;
            ViewBag.UserActivo = LoginController.UserActivo;
            ViewBag.Roles = Admin.ConsultarRolesDisponibles();

            ViewBag.Correos = Admin.ConsultarCorreosSinUsuario();
 
            return View(modelo);
        }

      
        [HttpPost]
        public ActionResult Actualizar(UserModel model)
        {

            bool respuesta = Admin.Actualizar(model);            
            return RedirectToAction("index");
        }


        /*

             public ActionResult Eliminar(int IdUser)
             {
                 eliminado = Admin.Eliminar(IdUser);
                 ViewBag.autenticado = autenticado;
                 return RedirectToAction("index", "UserController1");
             }
             */

    }
}