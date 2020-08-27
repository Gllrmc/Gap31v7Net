using Sistema.Entidades.Daybyday;
using Sistema.Entidades.Jerarquia;
using Sistema.Entidades.Motion;
using Sistema.Entidades.Pagos;
using Sistema.Entidades.Post;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sistema.Entidades.Proyectos
{
    public class Presupuesto
    {
        [Key]
        [Required]
        public int idpresupuesto { get; set; }
        [Required]
        [ForeignKey("proyecto")]
        public int idproyecto { get; set; }
        [Required]
        [ForeignKey("items")]
        public int iditem { get; set; }
        [ForeignKey("subitems")]
        public int? idsubitem { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal importe { get; set; }
        public string origen { get; set; }
        public int iduseralta { get; set; }
        public DateTime fecalta { get; set; }
        public int iduserumod { get; set; }
        public DateTime fecumod { get; set; }
        public bool activo { get; set; }

        public Proyecto proyecto { get; set; }
        public Item items { get; set; }
        public Subitem subitems { get; set; }
    }
}
