using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Maestros.Posiciones
{
    public class PosicionUpdateModel
    {
        [Required]
        public int idposicion { get; set; }
        [Required]
        public string posicion { get; set; }
        public int iduserumod { get; set; }
        public DateTime fecumod { get; set; }
    }
}
