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
    public class ManejadorUsuarios
    {
        Conexion conexion = new Conexion();

        public List<UserModel> Consultar() {

            List<UserModel> list = new List<UserModel>();
            DataTable datos = conexion.EjecutarConsulta("consultarUsuarios");
            foreach (DataRow dr in datos.AsEnumerable()) {
                list.Add(
                     new UserModel()
                     {
                         NOMBRE_USUARIO = dr["NOMBRE_USUARIO"].ToString(),
                         CONTRASENA = dr["CONTRASENA"].ToString(),
                         ROL = dr["NOMBRE_ROL"].ToString()
                     }
                    );
            }
            return list;
        }

        public List<UserModel> ConsultarUser(string nombreuser)
        {
            List<Parametro> lista = new List<Parametro>() {//
                         new Parametro("nombreUser",nombreuser)
            };

            List<UserModel> list = new List<UserModel>();
            DataTable datos = conexion.EjecutarConsulta("consultarUser", lista);

            foreach (DataRow dr in datos.AsEnumerable())
            {
                list.Add(
                     new UserModel()
                     {
                         ID_USUARIO = int.Parse(dr["ID_USUARIO"].ToString()),
                         NOMBRE_USUARIO = dr["NOMBRE_USUARIO"].ToString(),
                         CONTRASENA = dr["CONTRASENA"].ToString(),
                         CORREO = dr["CORREO"].ToString(),
                         ROL = dr["FK_ID_ROLES"].ToString()
                         
                     }
                    );
            }
            return list;
        }

        public List<PersonaModel> ConsultarCorreosSinUsuario()
        {

            List<PersonaModel> list = new List<PersonaModel>();
            DataTable datos = conexion.EjecutarConsulta("consultarCorreosSinUsuario");
            foreach (DataRow dr in datos.AsEnumerable())
            {
                list.Add(
                     new PersonaModel()
                     {
                         correo = dr["CORREO"].ToString(),
                     }
                    );
            }
            return list;
        }

        public List<UserModel> ConsultarRolesDisponibles()
        {

            List<UserModel> list = new List<UserModel>();
            DataTable datos = conexion.EjecutarConsulta("ConsultarRoles");
            foreach (DataRow dr in datos.AsEnumerable())
            {
                list.Add(
                     new UserModel()
                     {
                         ID_USUARIO = int.Parse( dr["ID_ROLES"].ToString()),
                         ROL = dr["NOMBRE_ROL"].ToString()
                     }
                    );
            }
            return list;
        }

      
        public bool Guardar(UserModel user){
                    List<Parametro> lista = new List<Parametro>() {
                        new Parametro("INNOMBRE",user.NOMBRE_USUARIO),
                        new Parametro("INCONTRASENA",user.CONTRASENA),
                        new Parametro("INCORREO",user.CORREO),
                        new Parametro("INROL",user.ROL)
                    };

                    return conexion.EjecutarTransaccion("guardarUsuario", lista);
        }


        public bool Actualizar(UserModel user)
        {
            List<Parametro> lista = new List<Parametro>() {//
                         new Parametro("INID",user.ID_USUARIO),
                        new Parametro("INNOMBRE",user.NOMBRE_USUARIO),
                        new Parametro("INCONTRASENA",user.CONTRASENA),
                        new Parametro("INCORREO",user.CORREO),
                        new Parametro("INROL",user.ROL)
            };

            return conexion.EjecutarTransaccion("actualizarUsuario", lista);
        }


        /*
                  public bool Eliminar(int id)
                  {
                      List<Parametro> lista = new List<Parametro>() {
                          new Parametro("id",id),
                      };

                      return conexion.EjecutarTransaccion("eliminar", lista);
                  }

                  public List<UserModel> ConsultarId(int id)
                  {
                      List<Parametro> lista = new List<Parametro>() {
                          new Parametro("idb",id),
                      };

                      List<UserModel> list = new List<UserModel>();
                      DataTable datos = conexion.EjecutarConsulta("consultarid",lista);
                      foreach (DataRow dr in datos.AsEnumerable())
                      {
                          list.Add(
                               new UserModel()
                               {
                                   IdUsuarios = int.Parse(dr["IdUsuarios"].ToString()),
                                   Nombre = dr["Nombre"].ToString(),
                                   Documento = dr["Documento"].ToString()
                               }
                              );
                      }
                      return list;
                  }*/

    }
}
