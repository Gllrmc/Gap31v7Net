using System.ComponentModel.DataAnnotations;

namespace Sistema.Web.Models.Maestros.Territorios
{
    public class TerritorioUpdateModel
    {
        [Required]
        public int idterritorio { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El territorio no debe tener mas de 50 caracteres, ni menos de 3 caracteres")]
        public string territorio { get; set; }
    }
}
