using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Maestros.Origenes
{
    public class OrigenUpdateModel
    {
        [Required]
        public int idorigen { get; set; }
        [Required]
        public int idterritorio { get; set; }
        [Required]
        public string origen { get; set; }
        public int iduserumod { get; set; }
        public DateTime fecumod { get; set; }
    }
}
