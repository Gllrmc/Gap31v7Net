using Sistema.Entidades.Gastos;
using Sistema.Entidades.Limbos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sistema.Entidades.Maestros
{
    public class Concepto
    {
        [Key]
        [Required]
        public int idconcepto { get; set; }
        [Required]
        public string concepto { get; set; }
        [Required]
        public string color { get; set; }
        public string texto { get; set; }
        public string cuentagcom { get; set; }
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
    }
}
