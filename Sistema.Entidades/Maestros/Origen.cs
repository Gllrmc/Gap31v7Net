using Sistema.Entidades.Limbos;
using Sistema.Entidades.Proyectos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sistema.Entidades.Maestros
{
    public class Origen
    {
        [Key]
        [Required]
        public int idorigen { get; set; }
        public string origen { get; set; }
        [Required]
        [ForeignKey("territorio")]
        public int idterritorio { get; set; }
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
        public Territorio territorio { get; set; }
        public ICollection<Proyecto> proyectos { get; set; }
        public ICollection<Limbo> limbos { get; set; }
    }
}
