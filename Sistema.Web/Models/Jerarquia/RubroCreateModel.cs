using System.ComponentModel.DataAnnotations;

namespace Sistema.Web.Models.Jerarquia
{
    public class RubroCreateModel
    {
        [Required]
        [StringLength(65, MinimumLength = 3, ErrorMessage = "El rubro(ES) no debe tener mas de 50 ni menos de 3 caracteres")]
        public string rubroes { get; set; }
        [Required]
        [StringLength(65, MinimumLength = 3, ErrorMessage = "El rubro(EN) no debe tener mas de 50 ni menos de 3 caracteres")]
        public string rubroen { get; set; }
        [Required]
        [StringLength(5, MinimumLength = 1, ErrorMessage = "El orden no debe tener mas de 5 ni menos de 1 caracter(es)")]
        public string orden { get; set; }
        [Required]
        public bool activo { get; set; }
    }
}
