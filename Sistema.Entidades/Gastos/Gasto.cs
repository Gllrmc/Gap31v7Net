using Sistema.Entidades.Maestros;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sistema.Entidades.Gastos
{
    public class Gasto
    {
        [Key]
        [Required]
        public int idgasto { get; set; }
        [Required]
        [ForeignKey("concepto")]
        public int idconcepto { get; set; }
        [Required]
        [ForeignKey("forpago")]
        public int idforpago { get; set; }
        [Required]
        [Column(TypeName = "date")]
        public DateTime fecgasto { get; set; }
        [Required]
        public decimal importe { get; set; }
        public string nota { get; set; }
        [Required]
        public bool pendiente { get; set; }
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
        public Concepto concepto { get; set; }
        public Forpago forpago { get; set; }
    }
}
