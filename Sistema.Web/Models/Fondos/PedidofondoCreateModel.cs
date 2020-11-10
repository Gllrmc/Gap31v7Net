using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Fondos
{
    public class PedidofondoCreateModel
    {
        [Required]
        public int idproyecto { get; set; }
        [Required]
        public int idsubrubro { get; set; }
        [Required]
        public int idresponsable { get; set; }
        [Required]
        public int numpedido { get; set; }
        [Required]
        public DateTime fecpedido { get; set; }
        [Required]
        public decimal importe { get; set; }
        public string notas { get; set; }
        public bool entregado { get; set; }
        public bool rendido { get; set; }
        public int iduseralta { get; set; }
        public DateTime fecalta { get; set; }
        public int iduserumod { get; set; }
        public DateTime fecumod { get; set; }
        public bool activo { get; set; }
    }
}
