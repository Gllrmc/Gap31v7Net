using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Maestros.Pitchs
{
    public class PitchUpdateModel
    {
        [Required]
        public int idpitch { get; set; }
        [Required]
        public string pitch { get; set; }
        public int iduserumod { get; set; }
        public DateTime fecumod { get; set; }
    }
}
