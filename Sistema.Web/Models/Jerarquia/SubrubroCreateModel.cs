using System.ComponentModel.DataAnnotations;

namespace Sistema.Web.Models.Jerarquia
{
    public class SubrubroCreateModel
    {
        [Required]
        public int idrubro { get; set; }
        [StringLength(65, MinimumLength = 3, ErrorMessage = "El subrubro(ES) no debe tener mas de 50 ni menos de 3 caracteres")]
        public string subrubroes { get; set; }
        [StringLength(65, MinimumLength = 3, ErrorMessage = "El subrubro(EN) no debe tener mas de 50 ni menos de 3 caracteres")]
        public string subrubroen { get; set; }
        [StringLength(5, MinimumLength = 1, ErrorMessage = "El orden no debe tener mas de 5 ni menos de 1 caracter(es)")]
        public string orden { get; set; }
        [Required]
        public int numhoja { get; set; }
        [Required]
        public bool post { get; set; }
        [Required]
        public bool vivo { get; set; }
        [Required]
        public bool conf { get; set; }
    }
}
