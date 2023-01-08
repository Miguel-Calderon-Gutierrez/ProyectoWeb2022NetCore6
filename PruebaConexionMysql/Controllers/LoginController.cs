using Microsoft.AspNetCore.Http;
using LogicaNegocio;
using LogicaNegocio.Models;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace PruebaConexionMysql.Controllers
{
    public class LoginController : Controller
    {
        public static bool autenticado = false;
        public static bool autenticadoaAdmin = false;
        public static string rolActivo = "";
        public static string UserActivo = "";
        // GET: HomeController1

        ManejadorLogin admin = new ManejadorLogin();

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> validar(LoginModel Usuario_)
        {
            LoginModel UsuarioIngreso = admin.validarUsuario(Usuario_.Nombre_usuario,Usuario_.clave_usuario);
            if (UsuarioIngreso != null)
            {
                autenticado = true;
                rolActivo = UsuarioIngreso.rol;
                UserActivo = UsuarioIngreso.Nombre_usuario;
                var claims = new List<Claim>() {
                    new Claim(ClaimTypes.Name, UsuarioIngreso.Nombre_usuario,UsuarioIngreso.rol)
                };

                var claimsIdentity  = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }

        public async Task<IActionResult> Salir() {

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            autenticado = false;
            rolActivo = "";
           
            return RedirectToAction("Index","Home");
        }

    

    }
}
