using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Maestros.Origenes
{
    public class OrigenViewModel
    {
        public int idorigen { get; set; }
        public string origen { get; set; }
        public int idterritorio { get; set; }
        public string territorio { get; set; }
        public int iduseralta { get; set; }
        public DateTime fecalta { get; set; }
        public int iduserumod { get; set; }
        public DateTime fecumod { get; set; }
        public bool activo { get; set; }
    }
}
