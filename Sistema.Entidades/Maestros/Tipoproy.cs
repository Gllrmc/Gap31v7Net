using Sistema.Entidades.Limbos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sistema.Entidades.Maestros
{
    public class Tipoproy
    {
        [Key]
        [Required]
        public int idtipoproy { get; set; }
        [Required]
        public string tipoproy { get; set; }
        [Required]
        public string descripcion { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal impvenmay { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal impvenmen { get; set; }
        [Required]
        [Column(TypeName = "decimal(5, 2)")]
        public decimal porganmay { get; set; }
        [Required]
        [Column(TypeName = "decimal(5, 2)")]
        public decimal porganmen { get; set; }
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
        public ICollection<Limbo> limbos { get; set; }

    }
}
