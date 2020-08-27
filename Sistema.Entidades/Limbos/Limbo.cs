using Sistema.Entidades.Maestros;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sistema.Entidades.Limbos
{
    public class Limbo
    {
        [Key]
        [Required]
        public int idlimbo { get; set; }
        [Required]
        public int orden { get; set; }
        [Required]
        public string proyecto { get; set; }
        [Required]
        [ForeignKey("clientes")]
        public int idcliente { get; set; }
        [Required]
        [ForeignKey("lep")]
        public int idep { get; set; }
        public Persona lep { get; set; }
        [Required]
        [ForeignKey("origenes")]
        public int idorigen { get; set; }
        [Required]
        [ForeignKey("agencias")]
        public int idagencia { get; set; }
        [Required]
        [ForeignKey("pitchs")]
        public int idpitch { get; set; }
        [Required]
        [ForeignKey("ldirector")]
        public int iddirector { get; set; }
        public Persona ldirector { get; set; }
        [ForeignKey("lcodirector")]
        public int? idcodirector { get; set; }
        public Persona lcodirector { get; set; }
        [Required]
        [ForeignKey("productoras")]
        public int idproductora { get; set; }
        [Required]
        [ForeignKey("tipoprods")]
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
        [Column(TypeName = "decimal(18, 2)")]
        public decimal impventa { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal impcontribucion { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal porcontribucion { get; set; }
        [Required]
        [ForeignKey("tipoproys")]
        public int idtipoproy { get; set; }
        [Required]
        [ForeignKey("estados")]
        public int idestado { get; set; }
        [Required]
        [Column(TypeName = "date")]
        public DateTime fecingreso { get; set; }
        [Column(TypeName = "date")]
        public DateTime? fecadjudicacion { get; set; }
        [Column(TypeName = "date")]
        public DateTime? fecpitch { get; set; }
        [Column(TypeName = "date")]
        public DateTime? fecrodaje { get; set; }
        [Column(TypeName = "date")]
        public DateTime? fecentrega { get; set; }
        [Required]
        public bool aprobacion { get; set; }
        public DateTime? fecaprobacion { get; set; }
        [ForeignKey("resultados")]
        public int? idresultado { get; set; }
        public string comentario { get; set; }
        [Required]
        public bool visitaforanea { get; set; }
        [Required]
        public bool postinhouse { get; set; }
        [Required]
        [ForeignKey("posiciones")]
        public int idposiciones { get; set; }
        [Required]
        public bool editinhouse { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? ars1usd { get; set; }
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
        public Origen origenes { get; set; }
        public Agencia agencias { get; set; }
        public Pitch pitchs { get; set; }
        public Cliente clientes { get; set; }
        public Productora productoras { get; set; }
        public Tipoprod tipoprods { get; set; }
        public Tipoproy tipoproys { get; set; }
        public Estado estados { get; set; }
        public Resultado resultados { get; set; }
        public Posicion posiciones { get; set; }
    }
}
