using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sistema.Entidades.Daybyday
{
    public class Sica
    {
        [Key]
        [Required]
        public int idsica { get; set; }
        [Required]
        public string asignacion { get; set; }
        [Required]
        public string cargo { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal horas8 { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal extras4 { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal total12 { get; set; }
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

        public ICollection<Tarifadxd> tarifadxds { get; set; }
    }
}
