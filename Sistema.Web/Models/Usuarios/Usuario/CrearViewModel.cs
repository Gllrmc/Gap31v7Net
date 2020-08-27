using System.ComponentModel.DataAnnotations;

namespace Sistema.Web.Models.Usuarios.Usuario
{
    public class CrearViewModel
    {
        [Required]
        public int idrol { get; set; }
        public int idpersona { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El userid no debe de tener más de 100, ni menos de 3 caracteres.")]
        public string userid { get; set; }
        public string telefono { get; set; }
        [Required]
        [EmailAddress]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public bool pxch { get; set; }
    }
}
