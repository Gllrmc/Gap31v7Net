

using System.ComponentModel.DataAnnotations;

namespace Sistema.Web.Models.Maestros.Empresas
{
    public class EmpresaCreateModel
    {
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "La empresa no debe tener mas de 50 caracteres, ni menos de 3 caracteres")]
        public string empresa { get; set; }
        [Required]
        public string cuit { get; set; }
        [Required]
        public string direccion { get; set; }
        [Required]
        public string localidad { get; set; }
        public string cpostal { get; set; }
        [Required]
        public int idprovincia { get; set; }
        [Required]
        public int idpais { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public string webpage { get; set; }
    }
}
