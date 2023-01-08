using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Models
{
    public class PuestoModel
    {
        public int ID_PUESTO_DONACION { get; set; }
        public String NOMBRE_PUESTO { get; set; }
        public String DIRECCION_PUESTO { get; set; }
        public String HORA_APERTURA { get; set; }
        public String HORA_CIERRE { get; set; }
        public int FK_EVENTO { get; set; }
    }
}
