using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Limbos
{
    public class LimboUpdateModel
    {
        [Required]
        public int idlimbo { get; set; }
        [Required]
        public int orden { get; set; }
        [Required]
        public string proyecto { get; set; }
        [Required]
        public int idep { get; set; }
        [Required]
        public int idorigen { get; set; }
        [Required]
        public int idpitch { get; set; }
        [Required]
        public int iddirector { get; set; }
        public int? idcodirector { get; set; }
        [Required]
        public int idtipoprod { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal impcosto { get; set; }
        [Required]
        [Column(TypeName = "decimal(5, 2)")]
        public decimal porcontingencia { get; set; }
        [Required]
        [Column(TypeName = "decimal(5, 2)")]
        public decimal porgastosfijo { get; set; }
        [Required]
        [Column(TypeName = "decimal(5, 2)")]
        public decimal porganancia { get; set; }
        [Required]
        [Column(TypeName = "decimal(5, 2)")]
        public decimal porfeedireccion { get; set; }
        [Required]
        [Column(TypeName = "decimal(5, 2)")]
        public decimal porotrosgastos { get; set; }
        [Required]
        [Column(TypeName = "decimal(5, 2)")]
        public decimal porcostofinanciero { get; set; }
        [Required]
        [Column(TypeName = "decimal(5, 2)")]
        public decimal porimpuestoycomision { get; set; }
        [Required]
        public int idtipoproy { get; set; }
        [Required]
        public int idestado { get; set; }
        [Required]
        public DateTime fecingreso { get; set; }
        public DateTime? fecadjudicacion { get; set; }
        public bool aprobacion { get; set; }
        public DateTime? fecaprobacion { get; set; }
        public int? idresultado { get; set; }
        public string comentario { get; set; }
        public decimal? ars1usd { get; set; }
        [Required]
        public int iduserumod { get; set; }
    }
}
