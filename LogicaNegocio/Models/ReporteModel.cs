using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Models
{
    public class ReporteModel
    {
        public string usuario { get; set; }
        public string fecha { get; set; }
        public string hora { get; set; }
        public String Fecha_ini { get; set; }
        public String Fecha_fin { get; set; }
        public List<BodegaModel> data { get; set; }
        public List<ModelDonar> data2 { get; set; }
        public List<BeneficiarioModel> data3 { get; set; }
        public ModelDonar donante{ get; set; }

        public BeneficiarioModel Beneficiario { get; set; }

        public List<BodegaModel> data4 { get; set; }

        public List<EventoModel> data5 { get; set; }

    }
}
