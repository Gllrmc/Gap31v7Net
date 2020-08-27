using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Maestros.Estados
{
    public class EstadoUpdateModel
    {
        [Required]
        public int idestado { get; set; }
        [Required]
        public string estado { get; set; }
        public int iduserumod { get; set; }
        public DateTime fecumod { get; set; }
    }
}
