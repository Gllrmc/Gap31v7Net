using System.ComponentModel.DataAnnotations;

namespace Sistema.Web.Models.Maestros.Provincias
{
    public class ProvinciaCreateModel
    {
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "La provincia no debe tener mas de 50 caracteres, ni menos de 3 caracteres")]
        public string provincia { get; set; }
    }
}
