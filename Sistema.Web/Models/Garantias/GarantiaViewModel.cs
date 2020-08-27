using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Garantias
{
    public class GarantiaViewModel
    {
        public int idgarantia { get; set; }
        public int idproyecto { get; set; }
        public int numorden { get; set; }
        public string proyectoorden { get; set; }
        public string proyecto { get; set; }
        public int idrubro { get; set; }
        public string rubro { get; set; }
        public int idproveedor { get; set; }
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
        public int iduseralta { get; set; }
        public DateTime fecalta { get; set; }
        public int iduserumod { get; set; }
        public DateTime fecumod { get; set; }
        public bool activo { get; set; }
    }
}
