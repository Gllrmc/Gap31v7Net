using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Maestros.Bancos
{
    public class BancoUpdateModel
    {
        [Required]
        public int idbanco { get; set; }
        [Required]
        public string nombre { get; set; }
        public int iduserumod { get; set; }
        public DateTime fecumod { get; set; }
    }
}
