
using System.ComponentModel.DataAnnotations;

namespace Sistema.Web.Models.Maestros.Agencias
{
    public class AgenciaCreateModel
    {
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "La agencia no debe tener mas de 50 caracteres, ni menos de 3 caracteres")]
        public string agencia { get; set; }
    }
}
