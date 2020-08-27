using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Jerarquia
{
    public class SubrubroViewModel
    {
        public int idsubrubro { get; set; }
        public int idrubro { get; set; }
        public string rubroorden { get; set; }
        public string rubroes { get; set; }
        public string rubroen { get; set; }
        public string subrubroes { get; set; }
        public string subrubroen { get; set; }
        public string subrubro { get; set; }
        public string orden { get; set; }
        public int numhoja { get; set; }
        public bool post { get; set; }
        public bool vivo { get; set; }
        public bool conf { get; set; }
        public bool activo { get; set; }
    }
}
