using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sistema.Entidades.Limbos
{
    public class Regpitch
    {
        [Key]
        [Required]
        public int idregpitch { get; set; }
        [Required]
        [ForeignKey("limbo")]
        public int idlimbo { get; set; }
        [Required]
        public int numregpitch { get; set; }
        [Required]
        [Column(TypeName = "date")]
        public DateTime fecregpitch { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal impregpitch { get; set; }
        public string pdfregpitch { get; set; }
        public string nota { get; set; }
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
        public Limbo limbo { get; set; }
    }
}
