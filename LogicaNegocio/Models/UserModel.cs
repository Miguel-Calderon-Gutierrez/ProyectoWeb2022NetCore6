using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LogicaNegocio.Models
{
    public class UserModel 
    {
        [DisplayName("ID")]
        public int ID_USUARIO { get; set; }
        [DisplayName("NOMBRE")]
        public string NOMBRE_USUARIO { get; set; }
        [DisplayName("CONTRASEÑA")]
        public string CONTRASENA { get; set; }
        [DisplayName("CORREO")]
        public string CORREO { get; set; }
        [DisplayName("ROL")]
        public string ROL { get; set; }
    }
}
