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
    public class ManejadorDonar
    {
        Conexion conexion = new Conexion();



        public List<PuestoDonarModel> ConsultarPuesto()
        {
            List<PuestoDonarModel> list = new List<PuestoDonarModel>();
            DataTable datos = conexion.EjecutarConsulta("consultarPuestoDonar");
            foreach (DataRow dr in datos.AsEnumerable())
            {
                list.Add(
                     new PuestoDonarModel()
                     {
                         ID_PUESTO_DONACION = int.Parse(dr["ID_PUESTO_DONACION"].ToString()),
                         NOMBRE_PUESTO = dr["NOMBRE_PUESTO"].ToString()
                     }
                    );
            }
            return list;
        }


        public List<TipoDonarModel> ConsultarTipo()
        {
            List<TipoDonarModel> list = new List<TipoDonarModel>();
            DataTable datos = conexion.EjecutarConsulta("consultarTipoDonar");
            foreach (DataRow dr in datos.AsEnumerable())
            {
                list.Add(
                     new TipoDonarModel()
                     {
                         ID_TIPO_DONACION = int.Parse(dr["ID_TIPO_DONACION"].ToString()),
                         NOMBRE_TIPO_DONACION = dr["NOMBRE_TIPO_DONACION"].ToString(),
                         UNIDAD_DE_MEDIDA = dr["UNIDAD_DE_MEDIDA"].ToString()
                     }
                    );
            }
            return list;
        }


        public List<ModelDonar> ConsultarDonaciones()
        {
            List<ModelDonar> list = new List<ModelDonar>();
            DataTable datos = conexion.EjecutarConsulta("consultarDonaciones");
            foreach (DataRow dr in datos.AsEnumerable())
            {
                list.Add(
                     new ModelDonar()
                     {
                         ID_DONACION = int.Parse(dr["ID_DONACION"].ToString()),
                         NOMBRE_DONANTE = dr["NOMBRE_DONANTE"].ToString(),
                         DOCUMENTO_DONANTE = dr["DOCUMENTO_DONANTE"].ToString(),
                         FECHA_DONACION = dr["FECHA_DONACION"].ToString().Split(" ")[0],
                         NOMBRE_PUESTO = dr["NOMBRE_PUESTO"].ToString()
                     }
                    );
            }
            return list;
        }

        public List<ModelDonar> ConsultarIdInfo(int id)
        {
            List<Parametro> lista = new List<Parametro>() {
                new Parametro("inID_DONACION",id),
            };

            List<ModelDonar> list = new List<ModelDonar>();
            DataTable datos = conexion.EjecutarConsulta("consultarDetalleDonacionesInfo", lista);
            foreach (DataRow dr in datos.AsEnumerable())
            {
                list.Add(
                     new ModelDonar()
                     {
                         DOCUMENTO_DONANTE = dr["DOCUMENTO_DONANTE"].ToString(),
                         NOMBRE_DONANTE = dr["NOMBRE_DONANTE"].ToString(),
                         FECHA_DONACION = dr["FECHA_DONACION"].ToString().Split(" ")[0],
                         NOMBRE_PUESTO = dr["NOMBRE_PUESTO"].ToString(),
                         NOMBRE_EVENTO = dr["NOMBRE_EVENTO"].ToString()
                     }
                    );
            }
            return list;
        }

        public List<ModelDonar> ConsultarIdDonacion(int id)
        {
            List<Parametro> lista = new List<Parametro>() {
                new Parametro("inID_DONACION",id),
            };

            List<ModelDonar> list = new List<ModelDonar>();
            DataTable datos = conexion.EjecutarConsulta("consultarDetalleDonaciones", lista);
            foreach (DataRow dr in datos.AsEnumerable())
            {
                list.Add(
                     new ModelDonar()
                     {
                         NOMBRE_TIPO_DONACION = dr["NOMBRE_TIPO_DONACION"].ToString(),
                         CANTIDAD_DONACION = int.Parse(dr["CANTIDAD_DONADA"].ToString())
                     }
                    );
            }
            return list;
        }

        public List<BodegaModel> ConsultarFacturaDetalle(int id)
        {
            List<Parametro> lista = new List<Parametro>() {
                new Parametro("inID_DONACION",id),
            };

            List<BodegaModel> list = new List<BodegaModel>();
            DataTable datos = conexion.EjecutarConsulta("consultarDetalleDonacionFactura", lista);
            foreach (DataRow dr in datos.AsEnumerable())
            {
                list.Add(
                     new BodegaModel()
                     {
                         NOMBRE_TIPO_DONACION = dr["NOMBRE_TIPO_DONACION"].ToString(),
                         CANTIDAD = int.Parse(dr["CANTIDAD_DONADA"].ToString()),
                         UNIDAD_DE_MEDIDA = dr["UNIDAD_DE_MEDIDA"].ToString()
                     }
                    );
            }
            return list;
        }


        public bool GuardarDonacion(ModelDonar donacion)
        {
            List<Parametro> lista = new List<Parametro>() {
                new Parametro("inNOMBRE_DONANTE",donacion.NOMBRE_DONANTE),
                new Parametro("inDOCUMENTO_DONANTE",donacion.DOCUMENTO_DONANTE),
                new Parametro("inFECHA_DONACION",donacion.FECHA_DONACION),
                new Parametro("inFK_ID_PUESTO_DONACION",donacion.FK_ID_PUESTO_DONACION),
            };

            return conexion.EjecutarTransaccion("guardarDonacion", lista);
        }

        public bool GuardarDetalle(ModelDonar donacion)
        {
            List<Parametro> lista = new List<Parametro>() {
                new Parametro("inCANTIDAD_DONADA",donacion.CANTIDAD_DONACION),
                new Parametro("inFK_ID_TIPO_DONACION",donacion.NOMBRE_TIPO_DONACION),
            };

            return conexion.EjecutarTransaccion("guardarDetalle", lista);
        }



        public string ConsultarDonante(string documento)
        {
            string nombreDonante = "";

            List<Parametro> lista = new List<Parametro>() {
                new Parametro("inDocumento",documento),
              
            };

            DataTable datos = conexion.EjecutarConsulta("consultarDonante",lista);
            foreach (DataRow dr in datos.AsEnumerable())
            {
                nombreDonante = dr["NOMBRE_DONANTE"].ToString();                       

            }

            return nombreDonante;
        }

        public bool GuardarJson(string json,int cant)
        {
            List<Parametro> lista = new List<Parametro>() {
                new Parametro("inJSON",json),
            };

            return conexion.EjecutarTransaccion("guardarDonacion", lista);
        }

    }
}
