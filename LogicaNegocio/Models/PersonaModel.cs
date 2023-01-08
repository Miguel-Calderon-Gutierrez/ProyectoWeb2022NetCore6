using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Models
{
    public class PersonaModel{
        [DisplayName("ID")]
        public int idPersona { get; set; }
        [DisplayName("PRIMER NOMBRE")]
        public string nombre1 { get; set; }
        [DisplayName("SEGUNDO NOMBRE")]
        public string nombre2 { get; set; }
        [DisplayName("PRIMER APELLIDO")]
        public string apellido1 { get; set; }
        [DisplayName("SEGUNDO APELLIDO")]
        public string apellido2 { get; set; }
        [DisplayName("CORREO")]
        public string correo { get; set; }
        [DisplayName("TELEFONO")]
        public string telefono { get; set; }

    }
}
