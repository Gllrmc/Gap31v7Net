using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Daybyday
{
    public class TarifadxdCreateModel
    {
        [Required]
        public int idproyecto { get; set; }
        [Required]
        public int iditem { get; set; }
        [Required]
        public int idsica { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal bruto8hs { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal extra4hs { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal bruto12hs { get; set; }
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
