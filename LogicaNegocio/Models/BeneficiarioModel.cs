using System;

namespace LogicaNegocio.Models
{
    public class BeneficiarioModel
    {

        public int ID_BENEFICIO { get; set; }
        public string NOMBRE_BENEFICIARIO { get; set; }

        public string FECHA_ENTREGA { get; set; }
        public int CANTIDAD_ENTREGADA { get; set; }

        public int FK_ID_PUESTO_DONACION { get; set; }

        public int FK_ID_TIPO_DONACION { get; set; }

        public string NOMBRE_TIPO_DONACION { get; set; }

        public string DOCUMENTO_BENEFICIARIO { get; set; }

        public string NOMBRE_PUESTO { get; set; }
        public string EVENTO { get; set; }

        public String NOMBRE_EVENTO { get; set; }
    }
}
