using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Fondos
{
    public class DistribucionfondoCreateModel
    {
        [Required]
        public int idpedidofondo { get; set; }
        [Required]
        public int idusuario { get; set; }
        [Required]
        public DateTime fecdistribucion { get; set; }
        [Required]
        public bool devolucion { get; set; }
        [Required]
        public decimal importe { get; set; }
        public string notas { get; set; }
        public bool rendido { get; set; }
        public int iduseralta { get; set; }
        public DateTime fecalta { get; set; }
        public int iduserumod { get; set; }
        public DateTime fecumod { get; set; }
        public bool activo { get; set; }
    }
}
