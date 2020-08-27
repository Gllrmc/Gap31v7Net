using Sistema.Entidades.Jerarquia;
using Sistema.Entidades.Maestros;
using Sistema.Entidades.Proyectos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sistema.Entidades.Daybyday
{
    public class Recursodxd
    {
        [Key]
        [Required]
        public int idrecursodxd { get; set; }
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
        [ForeignKey("crew")]
        public int idcrew { get; set; }
        [Required]
        public int idcont { get; set; }
        [Required]
        public DateTime fecdesde { get; set; }
        [Required]
        public DateTime fechasta { get; set; }
        [Required]
        public int dias8hs { get; set; }
        [Required]
        public int dias12hs { get; set; }
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
        public virtual Subitem subitem { get; set; }
        public Crew crew { get; set; }
        public ICollection<Realdxd> realdxd { get; set; }
    }
}
