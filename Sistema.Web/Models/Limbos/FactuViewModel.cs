using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Limbos
{
    public class FactuViewModel
    {
        public int idfactu { get; set; }
        public int idlimbo { get; set; }
        public string limbo { get; set; }
        public int numfactu { get; set; }
        public DateTime feccomprobante { get; set; }
        public string tipocomprobante { get; set; }
        public string numcomprobante { get; set; }
        public decimal impfactu { get; set; }
        public string nota { get; set; }
        public int iduseralta { get; set; }
        public DateTime fecalta { get; set; }
        public int iduserumod { get; set; }
        public DateTime fecumod { get; set; }
        public bool activo { get; set; }

    }
}
