using Sistema.Entidades.Jerarquia;
using Sistema.Entidades.Maestros;
using Sistema.Entidades.Proyectos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sistema.Entidades.Pagos
{
    public class Ordenpago
    {   
        [Key]
        [Required]
        public int idordenpago { get; set; }
        [Required]
        [ForeignKey("proyecto")]
        public int idproyecto { get; set; }
        [Required]
        [ForeignKey("item")]
        public int iditem { get; set; }
        [Required]
        [ForeignKey("subitem")]
        public int? idsubitem { get; set; }
        [Required]
        [ForeignKey("proveedor")]
        public int idproveedor { get; set; }
        [Required]
        [ForeignKey("alternativapago")]
        public int idalternativapago { get; set; }
        [Required]
        [ForeignKey("forpago")]
        public int idforpago { get; set; }
        [Required]
        public DateTime feccomprobante { get; set; }
        [Required]
        public string tipocomprobante { get; set; }
        [Required]
        public string numcomprobante { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal impsiniva { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal imptotal { get; set; }
        [Required]
        public DateTime fecpago { get; set; }
        public string pdfcomprobantefac { get; set; }
        [Required]
        public bool pagado { get; set; }
        public DateTime? fecpagado { get; set; }
        public string pdfcomprobantepago { get; set; }
        public string pdfcertificado1 { get; set; }
        public string pdfcertificado2 { get; set; }
        public string pdfcertificado3 { get; set; }
        public string pdfcertificado4 { get; set; }
        public string notas { get; set; }
        public int iduseralta { get; set; }
        [Required]
        public DateTime fecalta { get; set; }
        [Required]
        public int iduserumod { get; set; }
        [Required]
        public DateTime fecumod { get; set; }
        [Required]
        public bool activo { get; set; }

        public Proyecto proyecto { get; set; }
        public Item item { get; set; }
        public Subitem subitem { get; set; }
        public Proveedor proveedor { get; set; }
        public Alternativapago alternativapago { get; set; }
        public Forpago forpago { get; set; }
    }
}
