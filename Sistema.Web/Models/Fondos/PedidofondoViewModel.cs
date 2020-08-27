using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Fondos
{
    public class PedidofondoViewModel
    {
        public int idpedidofondo { get; set; }
        public int idproyecto { get; set; }
        public string orden { get; set; }
        public string proyecto { get; set; }
        public int idsubrubro { get; set; }
        public string subrubro { get; set; }
        public int idresponsable { get; set; }
        public string responsable { get; set; }
        public int numpedido { get; set; }
        public DateTime fecpedido { get; set; }
        public decimal importe { get; set; }
        public string notas { get; set; }
        public bool rendido { get; set; }
        public int iduseralta { get; set; }
        public DateTime fecalta { get; set; }
        public int iduserumod { get; set; }
        public DateTime fecumod { get; set; }
        public bool activo { get; set; }
    }
}
