using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Fondos
{
    public class PedidofondoSelectModel
    {
        public int idpedidofondo { get; set; }
        public int idproyecto { get; set; }
        public string orden { get; set; }
        public string proyecto { get; set; }
        public int idresponsable { get; set; }
        public string responsable { get; set; }
        public int numpedido { get; set; }
    }
}
