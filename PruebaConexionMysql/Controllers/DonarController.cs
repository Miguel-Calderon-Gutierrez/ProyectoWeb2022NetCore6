using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LogicaNegocio.Models;
using LogicaNegocio;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using System.Data;

namespace PruebaConexionMysql.Controllers
{
    [Authorize]
    public class DonarController : Controller
    {

        ManejadorDonar Admin = new ManejadorDonar();



        public static bool autenticado = LoginController.autenticado;
        public static bool transaccionNueva = false;
        public static bool transaccionRealizada = false;
        public List<PuestoDonarModel> Puestos=new List<PuestoDonarModel>();
        public List<TipoDonarModel> Tipos=new List<TipoDonarModel>();
        public List<ModelDonar> productos = new List<ModelDonar>();
        // GET: DonarController
        public IActionResult Index()
        {
            Puestos = Admin.ConsultarPuesto();
            Tipos = Admin.ConsultarTipo();
            ViewBag.Tipos = Tipos;
            ViewBag.Puestos = Puestos;
            ViewBag.autenticado = LoginController.autenticado;
            ViewBag.rol = LoginController.rolActivo;
            ViewBag.UserActivo = LoginController.UserActivo;
            return View();
        }

        public IActionResult Inicio()
        {
            IEnumerable<ModelDonar> lista = Admin.ConsultarDonaciones();

            ViewBag.autenticado = LoginController.autenticado;
            ViewBag.rol = LoginController.rolActivo;
            ViewBag.UserActivo = LoginController.UserActivo;

            ViewBag.transaccionNueva = transaccionNueva;
            ViewBag.transaccionRealizada = transaccionRealizada;

            transaccionNueva = false;
            transaccionRealizada = false;

            return View(lista);
        }

        public IActionResult Detalle(int ID_DONACION)
        {
            ViewBag.autenticado = LoginController.autenticado;
            ViewBag.rol = LoginController.rolActivo;
            ViewBag.UserActivo = LoginController.UserActivo;
            ModelDonar donante = Admin.ConsultarIdInfo(ID_DONACION)[0];
            productos = Admin.ConsultarIdDonacion(ID_DONACION);
            ViewBag.productos = productos;
            ViewBag.idDonacionReporte = ID_DONACION;
            return View(donante);
        }


        [HttpPost]
        public IActionResult crearDonacion(string json)
        {
            var s = 0;
            bool respuesta = false;
            DataTable dt = (DataTable)JsonConvert.DeserializeObject(json, (typeof(DataTable)));
            foreach (DataRow dr in dt.AsEnumerable())
            {
                if (s == 0)
                {
                    var ben2 = new ModelDonar()
                    {
                        NOMBRE_DONANTE = dr["donante"].ToString(),
                        DOCUMENTO_DONANTE = dr["documento"].ToString(),
                        FECHA_DONACION = dr["fecha"].ToString().Split(" ")[0],
                        FK_ID_PUESTO_DONACION = int.Parse(dr["puesto"].ToString())
                    };
                    Admin.GuardarDonacion(ben2);
                    s++;
                }
                var ben = new ModelDonar()
                {
                    CANTIDAD_DONACION = int.Parse(dr["cantidad"].ToString()),
                    NOMBRE_TIPO_DONACION = dr["tipo"].ToString()
                };
                respuesta = Admin.GuardarDetalle(ben);
            }
            return RedirectToAction("Inicio");
        }

        [HttpPost]
        public async Task<IActionResult> registrarDonacion(string json)
        {
            DataTable dt = (DataTable)JsonConvert.DeserializeObject(json, (typeof(DataTable)));
            int tamaño = dt.Rows.Count;
            
            bool resultado = Admin.GuardarJson(json,tamaño);
            return RedirectToAction("Inicio","Donar");
        }


        [HttpPost]
        public JsonResult llenarNombre(string documento)
        {
            
            string respuesta = Admin.ConsultarDonante(documento); 

            return Json(respuesta);
        }

    }
}
