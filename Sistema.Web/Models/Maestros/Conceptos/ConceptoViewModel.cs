using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Maestros.Conceptos
{
    public class ConceptoViewModel
    {
        [Required]
        public int idconcepto { get; set; }
        [Required]
        public string concepto { get; set; }
        [Required]
        public string color { get; set; }
        [Required]
        public string texto { get; set; }
        public string cuentagcom { get; set; }
        [Required]
        public int iduseralta { get; set; }
        [Required]
        public DateTime fecalta { get; set; }
        [Required]
        public int iduserumod { get; set; }
        [Required]
        public DateTime fecumod { get; set; }
        [Required]
        public bool activo { get; set; }
    }
}
