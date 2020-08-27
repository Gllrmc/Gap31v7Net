using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Proyectos
{
    public class PresupuestoUpdateModel
    {
        public int idpresupuesto { get; set; }
        [Required]
        public int idproyecto { get; set; }
        [Required]
        public int iditem { get; set; }
        public int? idsubitem { get; set; }
        [Required]
        public decimal importe { get; set; }
        [Required]
        public string origen { get; set; }
        public int iduserumod { get; set; }
        public DateTime fecumod { get; set; }
    }
}
