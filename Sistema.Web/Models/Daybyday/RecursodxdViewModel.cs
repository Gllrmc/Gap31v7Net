using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Daybyday
{
    public class RecursodxdViewModel
    {
        public int idrecursodxd { get; set; }
        public int idproyecto { get; set; }
        public string proyectoorden { get; set; }
        public string proyecto { get; set; }
        public int iditem { get; set; }
        public string itemorden { get; set; }
        public string itemes { get; set; }
        public string itemen { get; set; }
        public int? idsubitem { get; set; }
        public string subitemorden { get; set; }
        public string subitemes { get; set; }
        public string subitemen { get; set; }
        public int idcrew { get; set; }
        public int idcont { get; set; }
        public string nombre { get; set; }
        public string cuil { get; set; }
        public string sindicato { get; set; }
        public DateTime fecdesde { get; set; }
        public DateTime fechasta { get; set; }
        public int dias8hs { get; set; }
        public int dias12hs { get; set; }
        public int iduseralta { get; set; }
        public DateTime fecalta { get; set; }
        public int iduserumod { get; set; }
        public DateTime fecumod { get; set; }
        public bool activo { get; set; }
    }
}
