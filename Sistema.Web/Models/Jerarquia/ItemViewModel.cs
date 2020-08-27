using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Jerarquia
{
    public class ItemViewModel
    {
        //Master
        public int iditem { get; set; }
        public int idsubrubro { get; set; }
        public string rubroes { get; set; }
        public string rubroen { get; set; }
        public string subrubroorden { get; set; }
        public string subrubroes { get; set; }
        public string subrubroen { get; set; }
        public string itemes { get; set; }
        public string itemen { get; set; }
        public string orden { get; set; }
        public bool esdxd { get; set; }
        public bool espost { get; set; }
        public bool esmotion { get; set; }
        public bool tienesubitems { get; set; }
        public string cuentagcom { get; set; }
        public bool vivo { get; set; }
        public bool post { get; set; }
        public bool conf { get; set; }
        public int iduseralta { get; set; }
        public DateTime fecalta { get; set; }
        public int iduserumod { get; set; }
        public DateTime fecumod { get; set; }
        public bool activo { get; set; }
    }
}
