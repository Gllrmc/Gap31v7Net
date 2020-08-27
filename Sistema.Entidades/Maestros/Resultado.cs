using Sistema.Entidades.Limbos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sistema.Entidades.Maestros
{
    public class Resultado
    {
        [Key]
        [Required]
        public int idresultado { get; set; }
        [Required]
        public string resultado { get; set; }
        [Required]
        public bool esaprobacion { get; set; }
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
