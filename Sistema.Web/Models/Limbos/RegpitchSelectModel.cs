using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Limbos
{
    public class RegpitchSelectModel
    {
        public int idregpitch { get; set; }
        public int idlimbo { get; set; }
        public string limbo { get; set; }
        public int numregpitch { get; set; }
        public DateTime fecregpitch { get; set; }
        public decimal impregpitch { get; set; }
    }
}
