using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Proyectos
{
    public class FlujocajaCreateModel
    {
        [Required]
        public int idproyecto { get; set; }
        [Required]
        public int idrubro { get; set; }
        [Required]
        public string yearweek { get; set; }
        [Required]
        public string fromto { get; set; }
        [Required]
        public decimal tasadistribucion { get; set; }
        [Required]
        public decimal importe { get; set; }
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
