using Sistema.Entidades.Jerarquia;
using Sistema.Entidades.Maestros;
using Sistema.Entidades.Proyectos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sistema.Entidades.Fondos
{
    public class Pedidofondo
    {
        [Key]
        [Required]
        public int idpedidofondo { get; set; }
        [Required]
        [ForeignKey("proyecto")]
        public int idproyecto { get; set; }
        [Required]
        [ForeignKey("responsable")]
        public int idresponsable { get; set; }
        [Required]
        [ForeignKey("subrubro")]
        public int idsubrubro { get; set; }
        [Required]
        public int numpedido { get; set; }
        [Required]
        public DateTime fecpedido { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal importe { get; set; }
        public string notas { get; set; }
        [Required]
        public bool rendido { get; set; }
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

        public Persona responsable { get; set; }
        public Proyecto proyecto { get; set; }
        public Subrubro subrubro { get; set; }
        public ICollection<Distribucionfondo> distribucionfondos { get; set; }
    }
}
