using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Proyectos
{
    public class PresupuestoViewModel
    {
        public int idpresupuesto { get; set; }
        public int idproyecto { get; set; }
        public string proyecto { get; set; }
        public int iditem { get; set; }
        public string itemorden { get; set; }
        public string itemes { get; set; }
        public string itemen { get; set; }
        public int? idsubitem { get; set; }
        public string subitemorden { get; set; }
        public string subitemes { get; set; }
        public string subitemen { get; set; }
        public decimal importe { get; set; }
        public string origen { get; set; }
        public int iduseralta { get; set; }
        public DateTime fecalta { get; set; }
        public int iduserumod { get; set; }
        public DateTime fecumod { get; set; }
        public bool activo { get; set; }
    }
}
