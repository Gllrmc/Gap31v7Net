using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Fondos
{
    public class DistribucionheadViewModel
    {
        public int idproyecto { get; set; }
        public string orden { get; set; }
        public string proyecto { get; set; }
        public int idusuario { get; set; }
        public string usuario { get; set; }
        public int cantidad { get; set; }
        public decimal importe { get; set; }
        public int idultdistribucion { get; set; }
    }
}
