using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Garantias
{
    public class GarantiaUpdateModel
    {
        [Required]
        public int idgarantia { get; set; }
        [Required]
        public int idproyecto { get; set; }
        [Required]
        public int numorden { get; set; }
        [Required]
        public int idrubro { get; set; }
        [Required]
        public int idproveedor {get; set; }
        [Required]
        public decimal importe { get; set; }
        public string detalle { get; set; }
        public int? idbanco { get; set; }
        public string numcheque { get; set; }
        public DateTime? feccheque { get; set; }
        public DateTime? fecvencimiento { get; set; }
        [Required]
        public bool entregado { get; set; }
        [Required]
        public bool rendido { get; set; }
        public DateTime? fhrendido { get; set; }
        [Required]
        public int iduserumod { get; set; }
        [Required]
        public DateTime fecumod { get; set; }
    }
}
