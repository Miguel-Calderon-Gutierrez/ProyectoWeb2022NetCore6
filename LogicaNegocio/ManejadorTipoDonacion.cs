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
    public class ManejadorTipoDonacion
    {
        Conexion conexion = new Conexion();


        public bool Guardar(TipoDonacionModel tipoDonacion)
        {
            List<Parametro> lista = new List<Parametro>() {
                new Parametro("inNOMBRE_TIPO_DONACION",tipoDonacion.NOMBRE_TIPO_DONACION),
                new Parametro("inUNIDAD_DE_MEDIDA",tipoDonacion.UNIDAD_DE_MEDIDA)
            };

            return conexion.EjecutarTransaccion("agregarTipoDonacion", lista);
        }


        public List<UnidadModel> ConsultarUnidad()
        {
            List<UnidadModel> list = new List<UnidadModel>();
            DataTable datos = conexion.EjecutarConsulta("consultarUnidad");
            foreach (DataRow dr in datos.AsEnumerable())
            {
                list.Add(
                     new UnidadModel()
                     {
                         UNIDAD_DE_MEDIDA = dr["UNIDAD_DE_MEDIDA"].ToString()
                     }
                    );
            }
            return list;
        }


    }
}
