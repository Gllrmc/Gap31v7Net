using Sistema.Entidades.Jerarquia;
using Sistema.Entidades.Maestros;
using Sistema.Entidades.Proyectos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sistema.Entidades.Motion
{
    public class Proveedormotion
    {
        [Key]
        [Required]
        public int idproveedormotion { get; set; }
        [Required]
        [ForeignKey("proyecto")]
        public int idproyecto { get; set; }
        [Required]
        [ForeignKey("item")]
        public int iditem { get; set; }
        [ForeignKey("subitem")]
        public int? idsubitem { get; set; }
        [Required]
        [ForeignKey("proveedor")]
        public int idproveedor { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal tarifadiaria { get; set; }
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
        public Subitem subitem { get; set; }
        public Proveedor proveedor { get; set; }
        public ICollection<Realmotion> realmotions { get; set; }

    }
}
