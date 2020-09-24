using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Limbos
{
    public class FactuSelectModel
    {
        public int idfactu { get; set; }
        public int idlimbo { get; set; }
        public string limbo { get; set; }
        public int numfactu { get; set; }
        public DateTime feccomprobante { get; set; }
        public string tipocomprobante { get; set; }
        public string numcomprobante { get; set; }
        public decimal impfactu { get; set; }
    }
}
