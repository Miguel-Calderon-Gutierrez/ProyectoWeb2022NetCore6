using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Models
{
    public class ModelDonar
    {
        //[Required(ErrorMessage = "Las credenciales para Donar son necesarias")]
        
        
        public string NOMBRE_DONANTE { get; set; }

        public int CANTIDAD_DONACION { get; set; }

        public string FECHA_DONACION { get; set; }

        public int FK_ID_PUESTO_DONACION { get; set; }

        public int FK_ID_TIPO_DONACION { get; set; }

        public string NOMBRE_TIPO_DONACION { get; set; }

        public string DOCUMENTO_DONANTE { get; set; }

        public string NOMBRE_PUESTO { get; set; }

        public int ID_DONACION { get; set; }

        public string NOMBRE_EVENTO { get; set; }

    }
}
