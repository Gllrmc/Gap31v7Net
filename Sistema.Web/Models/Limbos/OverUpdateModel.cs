using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Limbos
{
    public class OverUpdateModel
    {
        [Required]
        public int idover { get; set; }
        [Required]
        [Column(TypeName = "date")]
        public DateTime fecover { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal impover { get; set; }
        public string pdfover { get; set; }
        public string nota { get; set; }
        public int iduserumod { get; set; }
    }
}
