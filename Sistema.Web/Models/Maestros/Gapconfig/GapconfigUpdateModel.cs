using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Maestros.Gapconfig
{
    public class GapconfigUpdateModel
    {
        [Required]
        public int id { get; set; }
        public string parametro { get; set; }
        public decimal valor { get; set; }
        public string texto { get; set; }
    }
}
