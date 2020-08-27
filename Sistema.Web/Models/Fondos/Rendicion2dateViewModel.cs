using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Fondos
{
    public class Rendicion2dateViewModel
    {
        public int idproyecto { get; set; }
        public string proy { get; set; }
        public string proyecto { get; set; }
        public int numpedido { get; set; }
        public string nombre { get; set; }
        public string origen { get; set; }
        public string rubro { get; set; }
        public int idsubrubro { get; set; }
        public string subrubro { get; set; }
        public string item { get; set; }
        public string subitem { get; set; }
        public decimal importe { get; set; }
    }
}
