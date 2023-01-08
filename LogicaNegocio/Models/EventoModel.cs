using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Models
{
    public class EventoModel
    {
        public int ID_EVENTO { get; set; }
        public string NOMBRE_EVENTO { get; set; }
        public string FECHA_INICIO { get; set; }
        public string FEHCA_FIN { get; set; }
        public string CATEGORIA_EVENTO { get; set; }
        public string DESCRIPCION { get; set; }
        public string ESTADO { get; set; }

    }
}
