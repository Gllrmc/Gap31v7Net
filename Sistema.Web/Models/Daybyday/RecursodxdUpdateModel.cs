using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Daybyday
{
    public class RecursodxdUpdateModel
    {
        [Required]
        public int idrecursodxd { get; set; }
        [Required]
        public int idproyecto { get; set; }
        [Required]
        public int iditem { get; set; }
        public int? idsubitem { get; set; }
        [Required]
        public int idcrew { get; set; }
        [Required]
        public int idcont { get; set; }
        [Required]
        public DateTime fecdesde { get; set; }
        [Required]
        public DateTime fechasta { get; set; }
        [Required]
        public int dias8hs { get; set; }
        [Required]
        public int dias12hs { get; set; }
        [Required]
        public int iduseralta { get; set; }
        [Required]
        public DateTime fecalta { get; set; }
        [Required]
        public int iduserumod { get; set; }
        [Required]
        public DateTime fecumod { get; set; }
    }
}
