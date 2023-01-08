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
    public class ManejadorFundacion
    {
        Conexion conexion = new Conexion();



        public List<FundacionModel> ConsultarFundacion()
        {
            List<FundacionModel> list = new List<FundacionModel>();
            DataTable datos = conexion.EjecutarConsulta("consultarFundacion");
            foreach (DataRow dr in datos.AsEnumerable())
            {
                list.Add(
                     new FundacionModel()
                     {
                         NOMBRE_FUNDACION = dr["NOMBRE__FUNDACION"].ToString(),
                         INFORMACION_FUNDACION = dr["INFORMACION_FUNDACION"].ToString(),
                         UBICACION = dr["UBICACION_FUNDACION"].ToString()
                     }
                    );
            }
            return list;
        }

        public bool ActualizarFundacion(FundacionModel informacion)
        {
            List<Parametro> lista = new List<Parametro>() {
                new Parametro("inNOMBRE__FUNDACION",informacion.NOMBRE_FUNDACION),
                new Parametro("inINFORMACION_FUNDACION",informacion.INFORMACION_FUNDACION),
                new Parametro("inUBICACION_FUNDACION",informacion.UBICACION)
            };

            return conexion.EjecutarTransaccion("ActualizarFundacion", lista);
        }


    }
}
