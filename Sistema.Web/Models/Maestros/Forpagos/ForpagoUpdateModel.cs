using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Maestros.Forpagos
{
    public class ForpagoUpdateModel
    {
        [Required]
        public int idforpago { get; set; }
        [Required]
        public string forpago { get; set; }
        [Required]
        public int iduserumod { get; set; }
    }
}
