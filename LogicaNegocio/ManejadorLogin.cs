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
    public class ManejadorLogin
    {
        Conexion conexion = new Conexion();

        public List<LoginModel> Consultar()
        {
            /*List<Parametro> lista = new List<Parametro>() {
                new Parametro("ID","1"),
            };
            */
            List<LoginModel> list = new List<LoginModel>();
            DataTable datos = conexion.EjecutarConsulta("consultarUsuarios");
            foreach (DataRow dr in datos.AsEnumerable())
            {
                list.Add(
                     new LoginModel()
                     {
                         Nombre_usuario = dr["NOMBRE_USUARIO"].ToString(),
                         clave_usuario = dr["CONTRASENA"].ToString(),
                         rol = dr["NOMBRE_ROL"].ToString()
                     }
                    );
            }
            return list;
        }

        public LoginModel validarUsuario(String nombre, String clave)
        {
            IEnumerable<LoginModel> listaLogin = Consultar();

            return listaLogin.Where(item => item.Nombre_usuario == nombre && item.clave_usuario == clave).FirstOrDefault();

        }

    }
}
