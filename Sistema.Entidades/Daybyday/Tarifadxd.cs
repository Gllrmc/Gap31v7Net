using Sistema.Entidades.Jerarquia;
using Sistema.Entidades.Proyectos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sistema.Entidades.Daybyday
{
    public class Tarifadxd
    {
        [Key]
        [Required]
        public int idtarifadxd { get; set; }
        [Required]
        [ForeignKey("proyecto")]
        public int idproyecto { get; set; }
        [Required]
        [ForeignKey("item")]
        public int iditem { get; set; }
        [Required]
        [ForeignKey("sica")]
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

        public Proyecto proyecto { get; set; }
        public Item item { get; set; }
        public Sica sica { get; set; }
    }
}
