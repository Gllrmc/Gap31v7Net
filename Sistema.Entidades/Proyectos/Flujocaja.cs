using Sistema.Entidades.Jerarquia;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sistema.Entidades.Proyectos
{
    public class Flujocaja
    {
        [Key]
        [Required]
        public int idflujocaja { get; set; }
        [Required]
        [ForeignKey("proyecto")]
        public int idproyecto { get; set; }
        [Required]
        [ForeignKey("rubro")]
        public int idrubro { get; set; }
        [Required]
        public string yearweek { get; set; }
        [Required]
        public string fromto { get; set; }
        [Required]
        [Column(TypeName = "decimal(5, 2)")]
        public decimal tasadistribucion { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal importe { get; set; }
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

        public Rubro rubro { get; set; }
        public Proyecto proyecto { get; set; }
    }
}
