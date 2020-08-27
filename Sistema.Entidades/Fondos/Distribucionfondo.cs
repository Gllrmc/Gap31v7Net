using Sistema.Entidades.Maestros;
using Sistema.Entidades.Usuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sistema.Entidades.Fondos
{
    public class Distribucionfondo
    {
        [Key]
        [Required]
        public int iddistribucionfondo { get; set; }
        [Required]
        [ForeignKey("pedidofondo")]
        public int idpedidofondo { get; set; }
        [Required]
        [ForeignKey("usuario")]
        public int idusuario { get; set; }
        [Required]
        public DateTime fecdistribucion { get; set; }
        [Required]
        public bool devolucion { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal importe { get; set; }
        [Required]
        public bool rendido { get; set; }
        public string notas { get; set; }
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

        public Pedidofondo pedidofondo { get; set; }
        public Usuario usuario { get; set; }
        public ICollection<Rendicionfondo> rendicionfondos { get; set; }
    }
}
