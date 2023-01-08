using AccesoDatos;
using LogicaNegocio.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class ManejadorReporte
    {
        Conexion conexion = new Conexion();



        public List<ModelDonar> ConsultarDonacionesFecha(FechaModel fecha)
        {

            List<Parametro> lista = new List<Parametro>() {
                new Parametro("inFECHA_INICIAL",fecha.Fecha_1),
                new Parametro("inFECHA_FINAL",fecha.Fecha_2)
            };

            DataTable datos = conexion.EjecutarConsulta("DonacionesFecha", lista);

            List<ModelDonar> list = new List<ModelDonar>();
            foreach (DataRow dr in datos.AsEnumerable())
            {
                list.Add(
                     new ModelDonar()
                     {
                         DOCUMENTO_DONANTE = dr["DOCUMENTO"].ToString(),
                         NOMBRE_DONANTE = dr["NOMBRE"].ToString(),
                         FECHA_DONACION = dr["FECHA_DONACION"].ToString().Split(" ")[0],
                         NOMBRE_EVENTO = dr["NOMBRE_EVENTO"].ToString()
                     }
                    );
            }
            return list;
        }

        public List<BeneficiarioModel> ConsultarBeneficiosFecha(FechaModel fecha)
        {

            List<Parametro> lista = new List<Parametro>() {
                new Parametro("inFECHA_INICIAL",fecha.Fecha_3),
                new Parametro("inFECHA_FINAL",fecha.Fecha_4)
            };

            DataTable datos = conexion.EjecutarConsulta("BeneficiosFecha", lista);

            List<BeneficiarioModel> list = new List<BeneficiarioModel>();
            foreach (DataRow dr in datos.AsEnumerable())
            {
                list.Add(
                     new BeneficiarioModel()
                     {
                         DOCUMENTO_BENEFICIARIO = dr["DOCUMENTO"].ToString(),
                         NOMBRE_BENEFICIARIO = dr["NOMBRE"].ToString(),
                         FECHA_ENTREGA = dr["FECHA_BENEFICIO"].ToString().Split(" ")[0],
                         NOMBRE_EVENTO = dr["NOMBRE_EVENTO"].ToString()
                     }
                    );
            }
            return list;
        }

        public List<EventoModel> consultarEventosParametro(FechaModel fecha)
        {

            List<Parametro> lista = new List<Parametro>() {
                new Parametro("inTIPO_EVENTO",fecha.tipo),
                new Parametro("inESTADO_EVENTO",fecha.estado)
            };

            DataTable datos = conexion.EjecutarConsulta("EventosTipo", lista);

            List<EventoModel> list = new List<EventoModel>();
            foreach (DataRow dr in datos.AsEnumerable())
            {
                list.Add(
                     new EventoModel()
                     {
                         NOMBRE_EVENTO = dr["NOMBRE_EVENTO"].ToString(),
                         FECHA_INICIO = dr["FECHA_INICIO"].ToString().Split(" ")[0],
                         FEHCA_FIN = dr["FEHCA_FIN"].ToString().Split(" ")[0]
                     }
                    );
            }
            return list;
        }



    }
}
