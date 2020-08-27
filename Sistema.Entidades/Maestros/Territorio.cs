using Sistema.Entidades.Proyectos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sistema.Entidades.Maestros
{
    public class Territorio
    {
        public int idterritorio { get; set; }
        [Required]
        public string territorio { get; set; }
        public bool activo { get; set; }
        public ICollection<Origen> origenes { get; set; }
    }
}
