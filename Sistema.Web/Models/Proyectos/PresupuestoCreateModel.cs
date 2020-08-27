using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Proyectos
{
    public class PresupuestoCreateModel
    {
        [Required]
        public int idproyecto { get; set; }
        [Required]
        public int iditem { get; set; }
        public int? idsubitem { get; set; }
        [Required]
        public decimal importe { get; set; }
        [Required]
        public string origen { get; set; }
        public int iduseralta { get; set; }
        public DateTime fecalta { get; set; }
        public int iduserumod { get; set; }
        public DateTime fecumod { get; set; }
        public bool activo { get; set; }
    }
}
