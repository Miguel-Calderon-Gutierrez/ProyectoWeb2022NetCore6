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
    public class ManejadorPuesto
    {
        Conexion conexion = new Conexion();



        public List<PuestoEventoModel> ConsultarEvento()
        {
            List<PuestoEventoModel> list = new List<PuestoEventoModel>();
            DataTable datos = conexion.EjecutarConsulta("consultarEventoPuesto");
            foreach (DataRow dr in datos.AsEnumerable())
            {
                list.Add(
                     new PuestoEventoModel()
                     {
                         ID_EVENTO = int.Parse(dr["ID_EVENTO"].ToString()),
                         NOMBRE_EVENTO = dr["NOMBRE_EVENTO"].ToString()
                     }
                    );
            }
            return list;
        }


        public List<PuestoModel> ConsultarPuestos()
        {
            List<PuestoModel> list = new List<PuestoModel>();
            DataTable datos = conexion.EjecutarConsulta("consultarPuesto");
            foreach (DataRow dr in datos.AsEnumerable())
            {
                list.Add(
                     new PuestoModel()
                     {
                         ID_PUESTO_DONACION = int.Parse(dr["ID_PUESTO_DONACION"].ToString()),
                         NOMBRE_PUESTO = dr["NOMBRE_PUESTO"].ToString(),
                         DIRECCION_PUESTO = dr["DIRECCION_PUESTO"].ToString(),
                         HORA_APERTURA = dr["HORA_APERTURA"].ToString(),
                         HORA_CIERRE = dr["HORA_CIERRE"].ToString(),
                         FK_EVENTO = int.Parse(dr["FK_EVENTO"].ToString())
                     }
                    );
            }
            return list;
        }


        public List<PuestoModel> ConsultarPuestosEvento(int id)
        {
           
            List<Parametro> lista = new List<Parametro>() {
                new Parametro("inFK_EVENTO",id)
            };

            DataTable datos = conexion.EjecutarConsulta("consultarPuestosEvento", lista);

            List<PuestoModel> list = new List<PuestoModel>();
            foreach (DataRow dr in datos.AsEnumerable())
            {
                list.Add(
                     new PuestoModel()
                     {
                         NOMBRE_PUESTO = dr["NOMBRE_PUESTO"].ToString(),
                         DIRECCION_PUESTO = dr["DIRECCION_PUESTO"].ToString(),
                     }
                    );
            }
            return list;
        }

        public bool Guardar(PuestoModel puesto)
        {
            List<Parametro> lista = new List<Parametro>() {
                new Parametro("inNOMBRE_PUESTO",puesto.NOMBRE_PUESTO),
                new Parametro("inDIRECCION_PUESTO",puesto.DIRECCION_PUESTO),
                new Parametro("inHORA_APERTURA",puesto.HORA_APERTURA),
                new Parametro("inHORA_CIERRE",puesto.HORA_CIERRE),
                new Parametro("inFK_EVENTO",puesto.FK_EVENTO)
            };

            return conexion.EjecutarTransaccion("agregarPuesto", lista);
        }

        public bool Actualizar(PuestoModel puesto)
        {
            List<Parametro> lista = new List<Parametro>() {
                new Parametro("inID_PUESTO_DONACION",puesto.ID_PUESTO_DONACION),
                new Parametro("inNOMBRE_PUESTO",puesto.NOMBRE_PUESTO),
                new Parametro("inDIRECCION_PUESTO",puesto.DIRECCION_PUESTO),
                new Parametro("inHORA_APERTURA",puesto.HORA_APERTURA),
                new Parametro("inHORA_CIERRE",puesto.HORA_CIERRE),
                new Parametro("inFK_EVENTO",puesto.FK_EVENTO)
            };

            return conexion.EjecutarTransaccion("actualizarPuesto", lista);
        }

        public List<PuestoModel> ConsultarId(int id)
        {
            List<Parametro> lista = new List<Parametro>() {
                new Parametro("inID_PUESTO_DONACION",id),
            };

            List<PuestoModel> list = new List<PuestoModel>();
            DataTable datos = conexion.EjecutarConsulta("consultarIdPuesto", lista);
            foreach (DataRow dr in datos.AsEnumerable())
            {
                list.Add(
                     new PuestoModel()
                     {
                         ID_PUESTO_DONACION = int.Parse(dr["ID_PUESTO_DONACION"].ToString()),
                         NOMBRE_PUESTO = dr["NOMBRE_PUESTO"].ToString(),
                         DIRECCION_PUESTO = dr["DIRECCION_PUESTO"].ToString(),
                         HORA_APERTURA = dr["HORA_APERTURA"].ToString(),
                         HORA_CIERRE = dr["HORA_CIERRE"].ToString(),
                         FK_EVENTO = int.Parse(dr["FK_EVENTO"].ToString())
                     }
                    );
            }
            return list;
        }


    }
}
