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
    public class ManejadorBodega
    {
        Conexion conexion = new Conexion();



        public List<BodegaModel> Consultar()
        {
            List<BodegaModel> list = new List<BodegaModel>();
            DataTable datos = conexion.EjecutarConsulta("verBodega");
            foreach (DataRow dr in datos.AsEnumerable())
            {
                list.Add(
                     new BodegaModel()
                     {
                         CANTIDAD = int.Parse(dr["CANTIDAD_RECOLECTADA"].ToString()),
                         NOMBRE_TIPO_DONACION = dr["NOMBRE_TIPO_DONACION"].ToString(),
                         UNIDAD_DE_MEDIDA = dr["UNIDAD_DE_MEDIDA"].ToString()
                     }
                    );
            }
            return list;
        }

    }
}
