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
    public class ManejadorPersona
    {
        Conexion conexion = new Conexion();

        public List<PersonaModel> Consultar()
        {
            List<PersonaModel> list = new List<PersonaModel>();
            DataTable datos = conexion.EjecutarConsulta("consultarPersonas");
            foreach (DataRow dr in datos.AsEnumerable())
            {
                list.Add(
                     new PersonaModel()
                     {   nombre1 = dr["NOMBRE1PERSONA"].ToString(),
                         nombre2 = dr["NOMBRE2PERSONA"].ToString(),
                         apellido1 = dr["APELLIDO1PERSONA"].ToString(),
                         apellido2 = dr["APELLIDO2PERSONA"].ToString(),
                         telefono = dr["TELEFONO"].ToString(),
                         correo = dr["CORREO"].ToString()                         
                     }
                    ) ;
            }
            return list;
        }

        public bool Guardar(PersonaModel persona)
        {
            List<Parametro> lista = new List<Parametro>() {
                
                new Parametro("inNOMBRE1PERSONA",persona.nombre1),
                new Parametro("inNOMBRE2PERSONA",persona.nombre2),
                new Parametro("inAPELLIDO1PERSONA",persona.apellido1),
                new Parametro("inAPELLIDO2PERSONA",persona.apellido2),
                new Parametro("inTELEFONO",persona.telefono),
                new Parametro("inCORREO",persona.correo)
            };

            return conexion.EjecutarTransaccion("guardarPersona", lista);
        }

        public bool Actualizar(PersonaModel persona)
        {
            List<Parametro> lista = new List<Parametro>() {
                new Parametro("inIDPERSONA",persona.idPersona),
                new Parametro("inNOMBRE1PERSONA",persona.nombre1),
                new Parametro("inNOMBRE2PERSONA",persona.nombre2),
                new Parametro("inAPELLIDO1PERSONA",persona.apellido1),
                new Parametro("inAPELLIDO2PERSONA",persona.apellido2),
                new Parametro("inTELEFONO",persona.telefono),
                new Parametro("inCORREO",persona.correo)
            };
            return conexion.EjecutarTransaccion("actualizarPersona", lista);
        }

        public bool Eliminar(string correo)
        {
            List<Parametro> lista = new List<Parametro>() {
                new Parametro("inCORREO",correo)
            };

            return conexion.EjecutarTransaccion("eliminarPersona", lista);
        }

        public List<PersonaModel> ConsultarCorreoPersona(string correo)
        {
            List<Parametro> lista = new List<Parametro>() {
                new Parametro("correoIn",correo),
            };
           
            DataTable datos = conexion.EjecutarConsulta("consultarPersonaCorreo", lista);

            List<PersonaModel> list = new List<PersonaModel>();
            foreach (DataRow dr in datos.AsEnumerable())
            {
                list.Add(
                     new PersonaModel()
                     {
                         idPersona = int.Parse(dr["ID_PERSONA"].ToString()),
                         nombre1 = dr["NOMBRE1PERSONA"].ToString(),
                         nombre2 = dr["NOMBRE2PERSONA"].ToString(),
                         apellido1 = dr["APELLIDO1PERSONA"].ToString(),
                         apellido2 = dr["APELLIDO2PERSONA"].ToString(),
                         telefono = dr["TELEFONO"].ToString(),
                         correo = dr["CORREO"].ToString()
                     }
                    );
            }
            return list;
        }
    }
}
