using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Pagos
{
    public class Op2dateViewModel
    {
        public int idproyecto { get; set; }
        public string proy { get; set; }
        public string proyecto { get; set; }
        public int idrubro { get; set; }
        public string rubro { get; set; }
        public int idsubrubro { get; set; }
        public string subrubro { get; set; }
        public int iditem { get; set; }
        public string item { get; set; }
        public int idsubitem { get; set; }
        public string subitem { get; set; }
        public string proveedor { get; set; }
        public string beneficiario { get; set; }
        public string cbu { get; set; }
        public DateTime feccomprobante { get; set; }
        public string tipocomprobante { get; set; }
        public string numcomprobante { get; set; }
        public decimal impneto { get; set; }
        public decimal imptotal { get; set; }
        public DateTime fecpago { get; set; }
        public bool pagado { get; set; }
        public DateTime fecpagado { get; set; }
        public string notas { get; set; }
    }
}
