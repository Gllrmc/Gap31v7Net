using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Garantias
{
    public class Garantia2dateViewModel
    {
        public int idgarantia { get; set; }
        public int idproyecto { get; set; }
        public string proy { get; set; }
        public string proyecto { get; set; }
        public int numorden { get; set; }
        public string rubro { get; set; }
        public string proveedor { get; set; }
        public decimal importe { get; set; }
        public string detalle { get; set; }
        public int? idbanco { get; set; }
        public string banco { get; set; }
        public string numcheque { get; set; }
        public DateTime? feccheque { get; set; }
        public DateTime? fecvencimiento { get; set; }
        public bool entregado { get; set; }
        public bool rendido { get; set; }
        public DateTime? fhrendido { get; set; }
    }
}
