using System.ComponentModel.DataAnnotations;

namespace Sistema.Web.Models.Maestros.Paises
{
    public class PaisUpdateModel
    {
        [Required]
        public int idpais { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El país no debe tener mas de 50 caracteres, ni menos de 3 caracteres")]
        public string pais { get; set; }
        public string cuit { get; set; }
    }
}
