
using System.ComponentModel.DataAnnotations;

namespace Sistema.Web.Models.Jerarquia
{
    public class RubroUpdateModel
    {
        [Required]
        public int idrubro { get; set; }
        [StringLength(65, MinimumLength = 3, ErrorMessage = "El rubroes no debe tener mas de 50 ni menos de 3 caracteres")]
        public string rubroes { get; set; }
        [StringLength(65, MinimumLength = 3, ErrorMessage = "El rubroen no debe tener mas de 50 ni menos de 3 caracteres")]
        public string rubroen { get; set; }
        [StringLength(5, MinimumLength = 1, ErrorMessage = "El orden no debe tener mas de 5 ni menos de 1 caracter(es)")]
        public string orden { get; set; }
    }
}
