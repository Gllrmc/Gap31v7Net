using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Daybyday
{
    public class SicaCreateModel
    {
        [Required]
        public string asignacion { get; set; }
        [Required]
        public string cargo { get; set; }
        [Required]
        public decimal horas8 { get; set; }
        [Required]
        public decimal extras4 { get; set; }
        [Required]
        public decimal total12 { get; set; }
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
