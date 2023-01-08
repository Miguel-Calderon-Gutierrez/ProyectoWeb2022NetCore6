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
    public class ManejadorBeneficiario
    {
        Conexion conexion = new Conexion();



        public List<PuestoDonarModel> ConsultarPuesto()
        {
            List<PuestoDonarModel> list = new List<PuestoDonarModel>();
            DataTable datos = conexion.EjecutarConsulta("consultarPuestoBeneficiario");
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
            DataTable datos = conexion.EjecutarConsulta("consultarTipoBeneficiario");
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


        public List<BeneficiarioModel> ConsultarBeneficiarios()
        {
            List<BeneficiarioModel> list = new List<BeneficiarioModel>();
            DataTable datos = conexion.EjecutarConsulta("consultarBeneficiario");
            foreach (DataRow dr in datos.AsEnumerable())
            {
                list.Add(
                     new BeneficiarioModel()
                     {
                         ID_BENEFICIO = int.Parse(dr["ID_BENEFICIO"].ToString()),
                         NOMBRE_BENEFICIARIO = dr["NOMBRE_BENEFICIARIO"].ToString(),
                         DOCUMENTO_BENEFICIARIO = dr["DOCUMENTO_BENEFICIARIO"].ToString(),
                         FECHA_ENTREGA = dr["FECHA_BENEFICIO"].ToString().Split(" ")[0],
                         NOMBRE_PUESTO = dr["NOMBRE_PUESTO"].ToString()
                     }
                    );
            }
            return list;
        }


        public List<BeneficiarioModel> ConsultarIdInfo(int id)
        {
            List<Parametro> lista = new List<Parametro>() {
                new Parametro("inID_BENEFICIO",id),
            };

            List<BeneficiarioModel> list = new List<BeneficiarioModel>();
            DataTable datos = conexion.EjecutarConsulta("consultarDetalleBeneficioInfo", lista);
            foreach (DataRow dr in datos.AsEnumerable())
            {
                list.Add(
                     new BeneficiarioModel()
                     {
                         DOCUMENTO_BENEFICIARIO = dr["DOCUMENTO_BENEFICIARIO"].ToString(),
                         NOMBRE_BENEFICIARIO = dr["NOMBRE_BENEFICIARIO"].ToString(),
                         FECHA_ENTREGA = dr["FECHA_BENEFICIO"].ToString().Split(" ")[0],
                         NOMBRE_PUESTO = dr["NOMBRE_PUESTO"].ToString(),
                         EVENTO = dr["NOMBRE_EVENTO"].ToString()
                     }
                    );
            }
            return list;
        }

        public List<BeneficiarioModel> ConsultarIdBeneficio(int id)
        {
            List<Parametro> lista = new List<Parametro>() {
                new Parametro("inID_BENEFICIO",id),
            };

            List<BeneficiarioModel> list = new List<BeneficiarioModel>();
            DataTable datos = conexion.EjecutarConsulta("consultarDetalleBeneficios", lista);
            foreach (DataRow dr in datos.AsEnumerable())
            {
                list.Add(
                     new BeneficiarioModel()
                     {
                         NOMBRE_TIPO_DONACION = dr["NOMBRE_TIPO_DONACION"].ToString(),
                         CANTIDAD_ENTREGADA = int.Parse(dr["CANTIDAD_ENTREGADA"].ToString())
                     }
                    );
            }
            return list;
        }

        public List<BodegaModel> ConsultarIdBeneficioFactura(int id)
        {
            List<Parametro> lista = new List<Parametro>() {
                new Parametro("inID_BENEFICIO",id),
            };

            List<BodegaModel> list = new List<BodegaModel>();
            DataTable datos = conexion.EjecutarConsulta("consultarDetalleBeneficios", lista);
            foreach (DataRow dr in datos.AsEnumerable())
            {
                list.Add(
                     new BodegaModel()
                     {
                         NOMBRE_TIPO_DONACION = dr["NOMBRE_TIPO_DONACION"].ToString(),
                         CANTIDAD = int.Parse(dr["CANTIDAD_ENTREGADA"].ToString()),
                         UNIDAD_DE_MEDIDA = dr["UNIDAD_DE_MEDIDA"].ToString()
                     }
                    );
            }
            return list;
        }


        public bool GuardarBeneficio(BeneficiarioModel beneficio)
        {
            List<Parametro> lista = new List<Parametro>() {
                new Parametro("inNOMBRE_BENEFICIARIO",beneficio.NOMBRE_BENEFICIARIO),
                new Parametro("inDOCUMENTO_BENEFICIARIO",beneficio.DOCUMENTO_BENEFICIARIO),
                new Parametro("inFECHA_BENEFICIO",beneficio.FECHA_ENTREGA),
                new Parametro("inFK_ID_PUESTO_DONACION",beneficio.FK_ID_PUESTO_DONACION),
            };

            return conexion.EjecutarTransaccion("guardarBeneficiario", lista);
        }

        public bool GuardarDetalleBeneficio(BeneficiarioModel beneficio)
        {
            List<Parametro> lista = new List<Parametro>() {
                new Parametro("inCANTIDAD_ENTREGADA",beneficio.CANTIDAD_ENTREGADA),
                new Parametro("inFK_ID_TIPO_DONACION",beneficio.NOMBRE_TIPO_DONACION),
            };

            return conexion.EjecutarTransaccion("guardarDetalleBeneficio", lista);
        }


        public string ConsultarBeneficiario(string documento)
        {
            string nombreBeneficiario = "";

            List<Parametro> lista = new List<Parametro>() {
                new Parametro("inDocumento",documento),

            };

            DataTable datos = conexion.EjecutarConsulta("consultarNombreBeneficiario", lista);
            foreach (DataRow dr in datos.AsEnumerable())
            {
                nombreBeneficiario = dr["NOMBRE_BENEFICIARIO"].ToString();

            }

            return nombreBeneficiario;
        }

        public bool GuardarJson(string json)
        {
            List<Parametro> lista = new List<Parametro>() {
                new Parametro("inJSON",json)
            };

            return conexion.EjecutarTransaccion("guardarBeneficiario", lista);
        }

    }
}
