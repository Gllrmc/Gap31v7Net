using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Maestros.Tipoprods
{
    public class TipoprodUpdateModel
    {
        [Required]
        public int idtipoprod { get; set; }
        [Required]
        public string tipoprod { get; set; }
        public int iduserumod { get; set; }
        public DateTime fecumod { get; set; }
    }
}
