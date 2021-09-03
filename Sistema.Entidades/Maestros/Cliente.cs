using Sistema.Entidades.Limbos;
using Sistema.Entidades.Proyectos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sistema.Entidades.Maestros
{
    public class Cliente
    {
        [Key]
        [Required]
        public int idcliente { get; set; }
        [ForeignKey("persona")]
        public int? idpersona { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "La razon social no puede ser mayor a {1} ni menor a {2} caracteres")]
        public string razonsocial { get; set; }
        [Required]
        public string cuit { get; set; }
        [Required]
        public string situacioniva { get; set; }
        [Required]
        public string situacioniibb { get; set; }
        public string jurisdiccion { get; set; }
        [Required]
        [EmailAddress]
        public string email { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
        public string localidad { get; set; }
        public string cpostal { get; set; }
        [Required]
        [ForeignKey("provincias")]
        public int idprovincia { get; set; }
        [Required]
        [ForeignKey("paises")]
        public int idpais { get; set; }
        [Required]
        public int iduseralta { get; set; }
        [Required]
        public DateTime fecalta { get; set; }
        [Required]
        public int iduserumod { get; set; }
        [Required]
        public DateTime fecumod { get; set; }
        public bool activo { get; set; }

        public Pais paises { get; set; }
        public Provincia provincias { get; set; }
        public Persona persona { get; set; }
        public ICollection<Proyecto> proyectos { get; set; }
    }
}
