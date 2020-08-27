using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Limbos
{
    public class LimboViewModel
    {
        public int idlimbo { get; set; }
        public int orden { get; set; }
        public string proyecto { get; set; }
        public int idcliente { get; set; }
        public string cliente { get; set; }
        public int idep { get; set; }
        public string ep { get; set; }
        public int idorigen { get; set; }
        public string origen { get; set; }
        public int idterritorio { get; set; }
        public string territorio { get; set; }
        public int idagencia { get; set; }
        public string agencia { get; set; }
        public int idpitch { get; set; }
        public string pitch { get; set; }
        public int iddirector { get; set; }
        public string director { get; set; }
        public int? idcodirector { get; set; }
        public string codirector { get; set; }
        public int idproductora { get; set; }
        public string productora { get; set; }
        public int idtipoprod { get; set; }
        public string tipoprod { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal impcosto { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal porcontingencia { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal porgastosfijo { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal porganancia { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal porfeedireccion { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal porotrosgastos { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal porcostofinanciero { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal porimpuestoycomision { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal impventa { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal impcontribucion { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal porcontribucion { get; set; }
        public int idtipoproy { get; set; }
        public string tipoproy { get; set; }
        public int idestado { get; set; }
        public string estado { get; set; }
        public DateTime fecingreso { get; set; }
        [DataType(DataType.Date)]
        public DateTime? fecadjudicacion { get; set; }
        [DataType(DataType.Date)]
        public DateTime? fecpitch { get; set; }
        [DataType(DataType.Date)]
        public DateTime? fecrodaje { get; set; }
        [DataType(DataType.Date)]
        public DateTime? fecentrega { get; set; }
        [Required]
        public bool aprobacion { get; set; }
        public DateTime? fecaprobacion { get; set; }
        public int? idresultado { get; set; }
        public string resultado { get; set; }
        public string comentario { get; set; }
        public bool visitaforanea { get; set; }
        public bool postinhouse { get; set; }
        public int idposiciones { get; set; }
        public string posiciones { get; set; }
        public bool editinhouse { get; set; }
        public decimal? ars1usd { get; set; }
        public int iduseralta { get; set; }
        public DateTime fecalta { get; set; }
        public int iduserumod { get; set; }
        public DateTime fecumod { get; set; }
        public bool activo { get; set; }
    }
}
