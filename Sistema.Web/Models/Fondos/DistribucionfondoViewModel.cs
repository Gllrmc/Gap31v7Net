using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Fondos
{
    public class DistribucionfondoViewModel
    {
        public int iddistribucionfondo { get; set; }
        public int idproyecto { get; set; }
        public string orden { get; set; }
        public string proyecto { get; set; }
        public int idpedidofondo { get; set; }
        public int numpedido { get; set; }
        public int idusuario { get; set; }
        public string usuario { get; set; }
        public DateTime fecdistribucion { get; set; }
        public  bool devolucion { get; set; }
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
