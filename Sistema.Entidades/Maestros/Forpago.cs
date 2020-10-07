using Sistema.Entidades.Gastos;
using Sistema.Entidades.Pagos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sistema.Entidades.Maestros
{
    public class Forpago
    {
        [Key]
        [Required]
        public int idforpago { get; set; }
        [Required]
        public string forpago { get; set; }
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
        public ICollection<Gasto> gastos { get; set; }
        public ICollection<Ordenpago> ordenpagos { get; set; }
    }
}
