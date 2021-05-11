using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Limbos
{
    public class RegpitchViewModel
    {
        public int idregpitch { get; set; }
        public int idlimbo { get; set; }
        public string limbo { get; set; }
        public int numregpitch { get; set; }
        public DateTime fecregpitch { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal impregpitch { get; set; }
        public string pdfregpitch { get; set; }
        public string nota { get; set; }
        public int iduseralta { get; set; }
        public DateTime fecalta { get; set; }
        public int iduserumod { get; set; }
        public DateTime fecumod { get; set; }
        public bool activo { get; set; }
    }
}
