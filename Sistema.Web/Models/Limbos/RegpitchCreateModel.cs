using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Limbos
{
    public class RegpitchCreateModel
    {
        [Required]
        public int idlimbo { get; set; }
        [Required]
        public DateTime fecregpitch { get; set; }
        [Required]
        public decimal impregpitch { get; set; }
        public string pdfregpitch { get; set; }
        public string nota { get; set; }
        [Required]
        public int iduseralta { get; set; }
    }
}
