using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sistema.Entidades.Limbos
{
    public class Dirfee
    {
        [Key]
        [Required]
        public int iddirfee { get; set; }
        [Required]
        [ForeignKey("limbo")]
        public int idlimbo { get; set; }
        [Required]
        public int numdirfee { get; set; }
        [Required]
        [Column(TypeName = "date")]
        public DateTime fecdirfee { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal impdirfee { get; set; }
        public string pdfdirfee { get; set; }
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
