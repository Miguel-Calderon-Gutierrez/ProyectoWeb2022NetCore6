
using LogicaNegocio;
using LogicaNegocio.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;

namespace PruebaConexionMysql.Controllers
{
    [Authorize]
    public class ReportesController : Controller
    {
        // GET: ReportesController
        [Authorize]

        public ActionResult Inicio(string descargar)
        {
            ManejadorBodega Admin = new ManejadorBodega();
            DateTime thisDay = DateTime.Today;
            string fecha = thisDay.ToString("d");
            string hora = DateTime.Now.ToString("hh:mm:ss tt");

            ReporteModel reporteModel = new ReporteModel()
            {
                usuario = LoginController.UserActivo,
                fecha = fecha,
                hora = hora,
                data = Admin.Consultar()
            };

            if (descargar == "true")
            {

                return new ViewAsPdf("Inicio", reporteModel)
                {
                    PageMargins = new Rotativa.AspNetCore.Options.Margins(0, 0, 0, 0),
                    FileName = "ReporteBodega.pdf"
                };
            }
            else {
                return new ViewAsPdf("Inicio", reporteModel)
                {
                    PageMargins = new Rotativa.AspNetCore.Options.Margins(0, 0, 0, 0)
                };
            }         
        }

        public ActionResult FechaDonacionesVer(FechaModel fecha2)
        {
            ManejadorReporte AdminReporte = new ManejadorReporte();
            DateTime thisDay = DateTime.Today;
            string fecha = thisDay.ToString("d");
            string hora = DateTime.Now.ToString("hh:mm:ss tt");

            ReporteModel reporteModel = new ReporteModel()
            {
                usuario = LoginController.UserActivo,
                fecha = fecha,
                hora = hora,
                Fecha_ini = fecha2.Fecha_1,
                Fecha_fin = fecha2.Fecha_2,
                data2 = AdminReporte.ConsultarDonacionesFecha(fecha2)
            };

            return new ViewAsPdf("PlantillaFechaDonacion", reporteModel)
            {
                PageMargins = new Rotativa.AspNetCore.Options.Margins(0, 0, 0, 0)
            };
        }

        public ActionResult FechaDonacionesDescargar(FechaModel fecha2)
        {
            ManejadorReporte AdminReporte = new ManejadorReporte();
            DateTime thisDay = DateTime.Today;
            string fecha = thisDay.ToString("d");
            string hora = DateTime.Now.ToString("hh:mm:ss tt");

            ReporteModel reporteModel = new ReporteModel()
            {
                usuario = LoginController.UserActivo,
                fecha = fecha,
                hora = hora,
                Fecha_ini=fecha2.Fecha_1,
                Fecha_fin=fecha2.Fecha_2,
                data2 = AdminReporte.ConsultarDonacionesFecha(fecha2)
            };

            return new ViewAsPdf("PlantillaFechaDonacion", reporteModel)
            {
                PageMargins = new Rotativa.AspNetCore.Options.Margins(0, 0, 0, 0),
                FileName = "ReporteDonacionesFecha.pdf"
            };
        }

        public ActionResult FechaBeneficiosVer(FechaModel fecha2)
        {
            ManejadorReporte AdminReporte = new ManejadorReporte();
            DateTime thisDay = DateTime.Today;
            string fecha = thisDay.ToString("d");
            string hora = DateTime.Now.ToString("hh:mm:ss tt");

            ReporteModel reporteModel = new ReporteModel()
            {
                usuario = LoginController.UserActivo,
                fecha = fecha,
                hora = hora,
                Fecha_ini = fecha2.Fecha_3,
                Fecha_fin = fecha2.Fecha_4,
                data3 = AdminReporte.ConsultarBeneficiosFecha(fecha2)
            };

            return new ViewAsPdf("PlantillaFechaBeneficio", reporteModel)
            {
                PageMargins = new Rotativa.AspNetCore.Options.Margins(0, 0, 0, 0)
            };
        }

        public ActionResult FechaBeneficiosDescargar(FechaModel fecha2)
        {
            ManejadorReporte AdminReporte = new ManejadorReporte();
            DateTime thisDay = DateTime.Today;
            string fecha = thisDay.ToString("d");
            string hora = DateTime.Now.ToString("hh:mm:ss tt");

            ReporteModel reporteModel = new ReporteModel()
            {
                usuario = LoginController.UserActivo,
                fecha = fecha,
                hora = hora,
                Fecha_ini = fecha2.Fecha_3,
                Fecha_fin = fecha2.Fecha_4,
                data3 = AdminReporte.ConsultarBeneficiosFecha(fecha2)
            };

            return new ViewAsPdf("PlantillaFechaBeneficio", reporteModel)
            {
                PageMargins = new Rotativa.AspNetCore.Options.Margins(0, 0, 0, 0),
                FileName = "ReporteBeneficiosFecha.pdf"
            };
        }


        public ActionResult facturaDonación(int idDonacion)
        {
            ManejadorReporte AdminReporte = new ManejadorReporte();
            ManejadorDonar adminDonar = new ManejadorDonar();


            DateTime thisDay = DateTime.Today;
            string fecha = thisDay.ToString("d");
            string hora = DateTime.Now.ToString("hh:mm:ss tt");

            ReporteModel reporteModel = new ReporteModel()
            {
                usuario = LoginController.UserActivo,
                fecha = fecha,
                hora = hora,
                donante = adminDonar.ConsultarIdInfo(idDonacion)[0],
                data4 = adminDonar.ConsultarFacturaDetalle(idDonacion)
            };

            return new ViewAsPdf("facturaDonación", reporteModel)
            {
                PageMargins = new Rotativa.AspNetCore.Options.Margins(0, 0, 0, 0),
                //FileName = "FacturaDonacion"+idDonacion+".pdf"
            };
        }

        public ActionResult facturaBeneficio(int idBeneficio)
        {
            ManejadorReporte AdminReporte = new ManejadorReporte();
            ManejadorBeneficiario adminBeneficio = new ManejadorBeneficiario();


            DateTime thisDay = DateTime.Today;
            string fecha = thisDay.ToString("d");
            string hora = DateTime.Now.ToString("hh:mm:ss tt");

            ReporteModel reporteModel = new ReporteModel()
            {
                usuario = LoginController.UserActivo,
                fecha = fecha,
                hora = hora,
                Beneficiario = adminBeneficio.ConsultarIdInfo(idBeneficio)[0],
                data4 = adminBeneficio.ConsultarIdBeneficioFactura(idBeneficio)
            };

            return new ViewAsPdf("facturaBeneficio", reporteModel)
            {
                PageMargins = new Rotativa.AspNetCore.Options.Margins(0, 0, 0, 0),
                //FileName = "FacturaDonacion"+idDonacion+".pdf"
            };
        }


        public ActionResult FechaEventosVer(FechaModel fecha2)
        {
            ManejadorReporte AdminReporte = new ManejadorReporte();
            DateTime thisDay = DateTime.Today;
            string fecha = thisDay.ToString("d");
            string hora = DateTime.Now.ToString("hh:mm:ss tt");

            ReporteModel reporteModel = new ReporteModel()
            {
                usuario = LoginController.UserActivo,
                fecha = fecha,
                hora = hora,
                Fecha_ini = fecha2.tipo,
                Fecha_fin = fecha2.estado,
                data5 = AdminReporte.consultarEventosParametro(fecha2)
            };

            return new ViewAsPdf("PlantillaEvento", reporteModel)
            {
                PageMargins = new Rotativa.AspNetCore.Options.Margins(0, 0, 0, 0)
            };
        }

        public ActionResult FechaEventosDescargar(FechaModel fecha2)
        {
            ManejadorReporte AdminReporte = new ManejadorReporte();
            DateTime thisDay = DateTime.Today;
            string fecha = thisDay.ToString("d");
            string hora = DateTime.Now.ToString("hh:mm:ss tt");

            ReporteModel reporteModel = new ReporteModel()
            {
                usuario = LoginController.UserActivo,
                fecha = fecha,
                hora = hora,
                Fecha_ini = fecha2.tipo,
                Fecha_fin = fecha2.estado,
                data5 = AdminReporte.consultarEventosParametro(fecha2)
            };

            return new ViewAsPdf("PlantillaEvento", reporteModel)
            {
                PageMargins = new Rotativa.AspNetCore.Options.Margins(0, 0, 0, 0),
                FileName = "ReporteEventos.pdf"
            };
        }


        public ActionResult Index()
        {

            ViewBag.autenticado = LoginController.autenticado;
            ViewBag.rol = LoginController.rolActivo;
            ViewBag.UserActivo = LoginController.UserActivo;
            return View();
        }

        public IActionResult Fecha()
        {
            ViewBag.autenticado = LoginController.autenticado;
            ViewBag.rol = LoginController.rolActivo;
            ViewBag.UserActivo = LoginController.UserActivo;
            return View();
        }

        public IActionResult PlantillaFechaDonacion()
        {
            return View();
        }

        public IActionResult PlantillaFechaBeneficio()
        {
            return View();
        }

        public IActionResult PlantillaEvento()
        {
            return View();
        }


        [HttpPost]
        public IActionResult FechaDonaciones1(FechaModel fecha3)
        {
            FechaModel fechaNueva = fecha3;
            return FechaDonacionesVer(fechaNueva);
        }

        [HttpPost]
        public IActionResult FechaDonaciones2(FechaModel fecha2)
        {
            FechaModel fechaNueva = fecha2;
            return FechaDonacionesDescargar(fechaNueva);
        }

        [HttpPost]

        public IActionResult FechaBeneficios1(FechaModel fecha3)
        {
            FechaModel fechaNueva = fecha3;
            return FechaBeneficiosVer(fecha3);
        }

        [HttpPost]

        public IActionResult FechaBeneficios2(FechaModel fecha)
        {
            FechaModel fechaNueva = fecha;
            return FechaBeneficiosDescargar(fechaNueva);
        }

        [HttpPost]
        public IActionResult EventosVer(FechaModel fecha)
        {
            FechaModel fechaNueva = fecha;
            return FechaEventosVer(fechaNueva);
        }

        [HttpPost]

        public IActionResult EventosDescargar(FechaModel fecha)
        {
            FechaModel fechaNueva = fecha;
            return FechaEventosDescargar(fechaNueva);
        }

    }
}
