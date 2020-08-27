using Sistema.Entidades.Limbos;
using Sistema.Entidades.Proyectos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sistema.Entidades.Maestros
{
    public class Productora
    {
        [Key]
        [Required]
        public int idproductora { get; set; }
        [Required]
        public string productora { get; set; }
        public bool activo { get; set; }

        public ICollection<Proyecto> proyectos { get; set; }
        public ICollection<Limbo> limbos { get; set; }
    }
}
