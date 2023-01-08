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
    public class ManejadorEvento
    {
        Conexion conexion = new Conexion();

       
        public List<EventoModel> Consultar()
        {
            List<EventoModel> list = new List<EventoModel>();
            DataTable datos = conexion.EjecutarConsulta("consultarEventosDisponibles");
            foreach (DataRow dr in datos.AsEnumerable())
            {
                list.Add(
                     new EventoModel()                     {
                         ID_EVENTO = int.Parse(dr["ID_EVENTO"].ToString()),
                         NOMBRE_EVENTO = dr["NOMBRE_EVENTO"].ToString(),
                         FECHA_INICIO = dr["FECHA_INICIO"].ToString().Split(" ")[0],
                         FEHCA_FIN = dr["FEHCA_FIN"].ToString().Split(" ")[0],
                         CATEGORIA_EVENTO = dr["CATEGORIA_EVENTO"].ToString(),
                         ESTADO = dr["ESTADO"].ToString()//ESTADO
                     }
                    );
            }
            return list;
        }

        public List<EventoModel> ConsultarEventosBuscador(string palabra)
        {
            List<EventoModel> list = new List<EventoModel>();

            List<Parametro> lista = new List<Parametro>() {
                         new Parametro("inNOMBRE_EVENTO",palabra)
            };

            DataTable datos = conexion.EjecutarConsulta("consultarBuscador",lista);
            foreach (DataRow dr in datos.AsEnumerable())
            {
                list.Add(
                     new EventoModel()
                     {
                         ID_EVENTO = int.Parse(dr["ID_EVENTO"].ToString()),
                         NOMBRE_EVENTO = dr["NOMBRE_EVENTO"].ToString(),
                         DESCRIPCION = dr["DESCRIPCION"].ToString(),
                         FECHA_INICIO = dr["FECHA_INICIO"].ToString().Split(" ")[0],
                         FEHCA_FIN = dr["FEHCA_FIN"].ToString().Split(" ")[0]
                     }
                    );
            }
            return list;
        }

        public bool Actualizar(EventoModel evento)
        {
            List<Parametro> lista = new List<Parametro>() {
                new Parametro("inID_EVENTO",evento.ID_EVENTO),
                new Parametro("inNOMBRE_EVENTO",evento.NOMBRE_EVENTO),
                new Parametro("inFECHA_INICIO",evento.FECHA_INICIO),
                new Parametro("inFEHCA_FIN",evento.FEHCA_FIN),
                new Parametro("inCATEGORIA_EVENTO",evento.CATEGORIA_EVENTO),
                new Parametro("inDESCRIPCION",evento.DESCRIPCION)
            };

            return conexion.EjecutarTransaccion("actualizarEvento", lista);
        }

        public bool ActualizarEstado(int id)
        {
            List<Parametro> lista = new List<Parametro>() {
                new Parametro("IDIN",id),
            };

            return conexion.EjecutarTransaccion("ActualizarEstadoEvento", lista);
        }


        public List<EventoModel> ConsultarIdEvento(int id)
        {
            List<Parametro> lista = new List<Parametro>() {
                new Parametro("inID_EVENTO",id),
            };

            List<EventoModel> list = new List<EventoModel>();
            DataTable datos = conexion.EjecutarConsulta("consultarIdEvento", lista);
            foreach (DataRow dr in datos.AsEnumerable())
            {
                list.Add(
                     new EventoModel()
                     {
                         ID_EVENTO = int.Parse(dr["ID_EVENTO"].ToString()),
                         NOMBRE_EVENTO = dr["NOMBRE_EVENTO"].ToString(),
                         FECHA_INICIO = dr["FECHA_INICIO"].ToString(),
                         FEHCA_FIN = dr["FEHCA_FIN"].ToString(),
                         CATEGORIA_EVENTO = dr["CATEGORIA_EVENTO"].ToString(),
                         DESCRIPCION = dr["DESCRIPCION"].ToString()
                     }
                    );
            }
            return list;
        }



        public bool Guardar(EventoModel Evento)
        {
            List<Parametro> lista = new List<Parametro>() {
                new Parametro("inNOMBRE_EVENTO",Evento.NOMBRE_EVENTO),
                new Parametro("inFECHA_INICIO",Evento.FECHA_INICIO),
                new Parametro("inFEHCA_FIN",Evento.FEHCA_FIN),
                new Parametro("inCATEGORIA_EVENTO",Evento.CATEGORIA_EVENTO),
                new Parametro("inDESCRIPCION",Evento.DESCRIPCION)
            };

            return conexion.EjecutarTransaccion("guardarEvento", lista);
        }


    }
}

