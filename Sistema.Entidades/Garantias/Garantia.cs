using Sistema.Entidades.Jerarquia;
using Sistema.Entidades.Maestros;
using Sistema.Entidades.Proyectos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sistema.Entidades.Garantias
{
    public class Garantia
    {
        [Key]
        [Required]
        public int idgarantia { get; set; }
        [Required]
        [ForeignKey("proyecto")]
        public int idproyecto { get; set; }
        [Required]
        public int numorden { get; set; }
        [Required]
        [ForeignKey("rubro")]
        public int idrubro { get; set; }
        [Required]
        [ForeignKey("proveedor")]
        public int idproveedor { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        [Required]
        public decimal importe { get; set; }
        public string detalle { get; set; }
        [ForeignKey("banco")]
        public int? idbanco { get; set; }
        public string numcheque { get; set; }
        public DateTime? feccheque { get; set; }
        public DateTime? fecvencimiento { get; set; }
        [Required]
        public bool entregado { get; set; }
        [Required]
        public bool rendido { get; set; }
        public DateTime? fhrendido { get; set; }
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
        public Rubro rubro { get; set; }
        public Proveedor proveedor { get; set; }
        public Banco banco { get; set; }






    }
}
