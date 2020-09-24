using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sistema.Entidades.Limbos
{
    public class Over
    {
        [Key]
        [Required]
        public int idover { get; set; }
        [Required]
        [ForeignKey("limbo")]
        public int idlimbo { get; set; }
        [Required]
        public int numover { get; set; }
        [Required]
        [Column(TypeName = "date")]
        public DateTime fecover { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal impover { get; set; }
        public string pdfover { get; set; }
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
