using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Limbos
{
    public class RegpitchUpdateModel
    {
        [Required]
        public int idregpitch { get; set; }
        [Required]
        [Column(TypeName = "date")]
        public DateTime fecregpitch { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal impregpitch { get; set; }
        public string pdfregpitch { get; set; }
        public string nota { get; set; }
        public int iduserumod { get; set; }
    }
}
