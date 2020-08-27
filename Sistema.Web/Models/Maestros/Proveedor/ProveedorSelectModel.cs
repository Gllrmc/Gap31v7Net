using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Maestros.Proveedor
{
    public class ProveedorSelectModel
    {
        public int idproveedor { get; set; }
        public string razonsocial { get; set; }
        public string situacioniva { get; set; }
        public string tipocomprobantegenerico { set; get; }
        public string cuit { get; set; }
    }
}
