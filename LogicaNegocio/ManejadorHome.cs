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
    public class ManejadorHome
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


    }
}
