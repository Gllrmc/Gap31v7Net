using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Jerarquia
{
    public class ItemCreateModel
    {
        [Required]
        public int idsubrubro { get; set; }
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El subrubro(ES) no debe tener mas de 50 ni menos de 3 caracteres")]
        public string itemes { get; set; }
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El subrubro(EN) no debe tener mas de 50 ni menos de 3 caracteres")]
        public string itemen { get; set; }
        [StringLength(5, MinimumLength = 1, ErrorMessage = "El orden no debe tener mas de 5 ni menos de 1 caracter(es)")]
        public string orden { get; set; }
        [Required]
        public bool esdxd { get; set; }
        [Required]
        public bool espost { get; set; }
        [Required]
        public bool esmotion { get; set; }
        [Required]
        public bool tienesubitems { get; set; }
        [Required]
        public string cuentagcom { get; set; }
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
