using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Maestros.Alternativapagos
{
    public class AlternativapagoCreateModel
    {
        [Required]
        public int idproveedor { get; set; }
        [Required]
        [StringLength(1, MinimumLength = 1, ErrorMessage = "El #Orden solo acepta 1 caracter.")]
        public string orden { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "El beneficiario no debe tener mas de 20 ni menos de 3 caracteres")]
        public string beneficiario { get; set; }
        public string banco { get; set; }
        [Required]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "El CUIT/CUIL debe tener 11 dígitos, sin guiones ni espacios")]
        public string cuitcuil { get; set; }
        public string tipocuenta { get; set; }
        public string numcuenta { get; set; }
        public string cbu { get; set; }
        public string alias { get; set; }
        [Required]
        public int iduseralta { get; set; }
        [Required]
        public DateTime fecalta { get; set; }
        [Required]
        public int iduserumod { get; set; }
        [Required]
        public DateTime fecumod { get; set; }
        [Required]
        public bool activo { get; set; }
    }
}
