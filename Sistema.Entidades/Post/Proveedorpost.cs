using Sistema.Entidades.Jerarquia;
using Sistema.Entidades.Maestros;
using Sistema.Entidades.Proyectos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sistema.Entidades.Post
{
    public class Proveedorpost
    {
        [Key]
        [Required]
        public int idproveedorpost { get; set; }
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
        public ICollection<Realpost> realposts { get; set; }
    }
}
