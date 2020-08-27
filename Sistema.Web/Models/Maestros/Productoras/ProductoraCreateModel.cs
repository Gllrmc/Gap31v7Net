
using System.ComponentModel.DataAnnotations;

namespace Sistema.Web.Models.Maestros.Productoras
{
    public class ProductoraCreateModel
    {
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "La productora no debe tener mas de 50 caracteres, ni menos de 3 caracteres")]
        public string productora { get; set; }
    }
}
