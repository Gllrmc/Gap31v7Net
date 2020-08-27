using Sistema.Entidades.Jerarquia;
using Sistema.Entidades.Maestros;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sistema.Entidades.Fondos
{
    public class Rendicionfondo
    {
        [Key]
        [Required]
        public int idrendicionfondo { get; set; }
        [Required]
        [ForeignKey("distribucionfondo")]
        public int iddistribucionfondo { get; set; }
        [Required]
        [ForeignKey("item")]
        public int iditem { get; set; }
        [ForeignKey("subitem")]
        public int? idsubitem { get; set; }
        [Required]
        [ForeignKey("proveedor")]
        public int? idproveedor { get; set; }
        public string tipocomprobante { get; set; }
        public string numcomprobante { get; set; }
        [Required]
        public DateTime feccomprobante { get; set; }
        [Required]
        public string indiceinterno { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal impsiniva { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal imptotal { get; set; }
        public string notas { get; set; }
        public string pdfcomprobante { get; set; }
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

        public Distribucionfondo distribucionfondo { get; set; }
        public Item item { get; set; }
        public Subitem subitem { get; set; }
        public Proveedor proveedor { get; set; }
    }
}
