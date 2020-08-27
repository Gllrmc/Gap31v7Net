using Sistema.Entidades.Proyectos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sistema.Entidades.Maestros
{
    public class Empresa
    {
        [Key]
        [Required]
        public int idempresa { get; set; }
        [Required]
        public string empresa { get; set; }
        [Required]
        public string cuit { get; set; }
        public string direccion { get; set; }
        public string localidad { get; set; }
        public string cpostal { get; set; }
        [Required]
        [ForeignKey("provincia")]
        public int idprovincia { get; set; }
        [Required]
        [ForeignKey("pais")]
        public int idpais { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public string webpage { get; set; }
        public bool activo { get; set; }

        public Pais pais { get; set; }
        public Provincia provincia { get; set; }
        public ICollection<Proyecto> proyectos { get; set; }
    }
}
