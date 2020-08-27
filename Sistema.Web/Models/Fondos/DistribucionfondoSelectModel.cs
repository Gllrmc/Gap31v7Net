using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Fondos
{
    public class DistribucionfondoSelectModel
    {
        public int iddistribucionfondo { get; set; }
        public int idproyecto { get; set; }
        public string orden { get; set; }
        public string proyecto { get; set; }
        public int idpedidofondo { get; set; }
        public int numpedido { get; set; }
        public int idusuario { get; set; }
        public string usuario { get; set; }
    }
}
