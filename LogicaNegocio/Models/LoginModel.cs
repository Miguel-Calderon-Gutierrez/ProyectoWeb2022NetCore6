using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LogicaNegocio.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Las credenciales para iniciar son necesarias")]
        public String Nombre_usuario { get; set; }
        public String clave_usuario { get; set; }
        public String rol { get; set; }
    }
}
