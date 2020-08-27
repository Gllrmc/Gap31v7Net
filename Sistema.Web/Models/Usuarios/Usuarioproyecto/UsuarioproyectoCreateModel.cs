using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Usuarios.Usuarioproyecto
{
    public class UsuarioproyectoCreateModel
    {
        [Required]
        public int idusuario { get; set; }
        [Required]
        public int idproyecto { get; set; }
        [Required]
        public bool vivo { get; set; }
        [Required]
        public bool post { get; set; }
        [Required]
        public bool confidencial { get; set; }
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
    }
}
