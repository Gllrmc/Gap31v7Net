using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Limbos
{
    public class OverCreateModel
    {
        [Required]
        public int idlimbo { get; set; }
        [Required]
        public DateTime fecover { get; set; }
        [Required]
        public decimal impover { get; set; }
        public string pdfover { get; set; }
        public string nota { get; set; }
        [Required]
        public int iduseralta { get; set; }
    }
}
