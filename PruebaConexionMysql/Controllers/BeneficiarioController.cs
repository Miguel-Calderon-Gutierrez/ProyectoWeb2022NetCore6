using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LogicaNegocio.Models;
using LogicaNegocio;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Newtonsoft.Json;

namespace PruebaConexionMysql.Controllers
{
    [Authorize]
    public class BeneficiarioController : Controller
    {

        public static bool autenticado = LoginController.autenticado;

        ManejadorBeneficiario Admin = new ManejadorBeneficiario();

        public List<PuestoDonarModel> Puestos = new List<PuestoDonarModel>();
        public List<TipoDonarModel> Tipos = new List<TipoDonarModel>();
        public List<BeneficiarioModel> productos = new List<BeneficiarioModel>();


        // GET: BeneficiarioController
        public IActionResult Index()
        {
            Puestos = Admin.ConsultarPuesto();
            Tipos = Admin.ConsultarTipo();
            ViewBag.Puestos = Puestos;
            ViewBag.Tipos = Tipos;
            ViewBag.autenticado = LoginController.autenticado;
            ViewBag.rol = LoginController.rolActivo;
            ViewBag.UserActivo = LoginController.UserActivo;
            return View();
        }

       

        public IActionResult Inicio()
        {
            IEnumerable<BeneficiarioModel> lista = Admin.ConsultarBeneficiarios();
            ViewBag.autenticado = LoginController.autenticado;
            ViewBag.rol = LoginController.rolActivo;
            ViewBag.UserActivo = LoginController.UserActivo;
            return View(lista);
        }


        public IActionResult Detalle(int ID_BENEFICIO)
        {
            ViewBag.autenticado = LoginController.autenticado;
            ViewBag.rol = LoginController.rolActivo;
            ViewBag.UserActivo = LoginController.UserActivo;
            BeneficiarioModel beneficiario = Admin.ConsultarIdInfo(ID_BENEFICIO)[0];
            productos = Admin.ConsultarIdBeneficio(ID_BENEFICIO);
            ViewBag.productos = productos;
            ViewBag.idDetalle = ID_BENEFICIO;
            return View(beneficiario);
        }

        [HttpPost]
        public JsonResult crearBeneficiario(string json) {
            bool respuesta = false;
            var s = 0;
            DataTable dt = (DataTable)JsonConvert.DeserializeObject(json, (typeof(DataTable)));
            foreach (DataRow dr in dt.AsEnumerable()) {
                if (s == 0)
                {
                    var ben2 = new BeneficiarioModel()
                    {
                        NOMBRE_BENEFICIARIO = dr["donante"].ToString(),
                        DOCUMENTO_BENEFICIARIO = dr["documento"].ToString(),
                        FECHA_ENTREGA = dr["fecha"].ToString().Split(" ")[0],
                        FK_ID_PUESTO_DONACION = int.Parse(dr["puesto"].ToString())
                    };
                    Admin.GuardarBeneficio(ben2);
                    s++;
                }
                var ben = new BeneficiarioModel()
                {
                    CANTIDAD_ENTREGADA = int.Parse(dr["cantidad"].ToString()),
                    NOMBRE_TIPO_DONACION = dr["tipo"].ToString()
                };

              respuesta = Admin.GuardarDetalleBeneficio(ben);
            }
            return Json(respuesta);
        }

        [HttpPost]
        public JsonResult llenarNombre(string documento)
        {

            string respuesta = Admin.ConsultarBeneficiario(documento);

            return Json(respuesta);
        }

        [HttpPost]
        public async Task<IActionResult> registrarBeneficio(string json)
        {
            DataTable dt = (DataTable)JsonConvert.DeserializeObject(json, (typeof(DataTable)));
            int tamaño = dt.Rows.Count;
            bool resultado = Admin.GuardarJson(json);
            return RedirectToAction("Inicio", "Beneficiario");
        }

    }
}
