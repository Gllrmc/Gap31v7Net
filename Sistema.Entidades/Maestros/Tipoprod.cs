using Sistema.Entidades.Limbos;
using Sistema.Entidades.Proyectos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sistema.Entidades.Maestros
{
    public class Tipoprod
    {
        [Key]
        [Required]
        public int idtipoprod { get; set; }
        public string tipoprod { get; set; }
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
        public ICollection<Proyecto> proyectos { get; set; }
        public ICollection<Limbo> limbos { get; set; }

    }
}
