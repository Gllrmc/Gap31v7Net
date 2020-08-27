using Sistema.Entidades.Fondos;
using Sistema.Entidades.Maestros;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sistema.Entidades.Usuarios
{
    public class Usuario
    {
        [Key]
        [Required]
        public int idusuario { get; set; }
        [Required]
        [ForeignKey("rol")]
        public int idrol { get; set; }
        [ForeignKey("persona")]
        public int idpersona { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El userid no debe de tener más de 100, ni menos de 3 caracteres.")]
        public string userid { get; set; }
        public string telefono { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public byte[] password_hash { get; set; }
        [Required]
        public byte[] password_salt { get; set; }
        [Required]
        public bool pxch { get; set; }
        public bool condicion { get; set; }

        public Rol rol { get; set; }
        public Persona persona { get; set; }
        public ICollection<Usuarioproyecto> usuarioproyectos { get; set; }
        public ICollection<Distribucionfondo> distribucionfondos { get; set; }


    }
}
